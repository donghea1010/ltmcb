﻿// The Server class, which is what hosts the game and interacts with clients.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;

namespace OnlineMonopoly
{
    class Server
    {
    	// Constructor for the Server.
    	public Server()
    	{
    		// Set up the socket.
    		m_serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    		// Set up the list.
    		m_clientSockets = new List<Socket>();
            // Set up the game.
            m_game = new Game();
            // The game hasn't started yet, so...
            m_gameStarted = false;
    	}
    	
    	public void SetUpServer()
    	{
    		// Tell the console window we are setting up the server.
    		Console.WriteLine("Setting up the game server...");
    		// Set up the server.
    		m_serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
    		m_serverSocket.Listen(1);
    		m_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    	}
        
        public enum Command
        {
            Yes, No, Join, Roll, Chat, Done, Start, NoStart, TurnStart, PositionUpdate, FundUpdate, ShowMessageBox,
            RentBox, BuyProperty, Mortgage, Unmortgage, Tax, Jail, Card, GetNames, GetProperties, GetFunds,
            TradeRequest, AcceptTrade, DeclineTrade, GetBuildingProperties, GetBuildingInfo, BuyBuilding,
            SellBuilding, BankruptWarning, Bankrupt, Winner, None
        }
        
        public struct PlayerCommand
        {
            public string Name
            {
                get
                {
                    return s_name;
                }
                set
                {
                    s_name = value;
                }
            }
            public Command Command
            {
                get
                {
                    return s_command;
                }
                set
                {
                    s_command = value;
                }
            }
            public string Message
            {
                get
                {
                    return s_message;
                }
                set
                {
                    s_message = value;
                }
            }
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
            private string s_name;
            private Command s_command;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 510)]
            private string s_message;
        }
        
        private byte[] GetBytes(PlayerCommand a_command)
        {
            // Get the size of the struct.
            int size = Marshal.SizeOf(a_command);
            byte[] data = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(a_command, ptr, false);
            Marshal.Copy(ptr, data, 0, size);
            Marshal.FreeHGlobal(ptr);
            return data;
        }
        
        private PlayerCommand GetStruct(byte[] a_bytes)
        {
            PlayerCommand structure = new PlayerCommand();

            int size = Marshal.SizeOf(structure);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(a_bytes, 0, ptr, size);
            structure = (PlayerCommand)Marshal.PtrToStructure(ptr, structure.GetType());
            Marshal.FreeHGlobal(ptr);

            return structure;
        }
       
    	private void AcceptCallback(IAsyncResult AR)
    	{
    		// Accept a client.
    		Socket socket = m_serverSocket.EndAccept(AR);
            // Receive the join command.
            socket.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            // Add the socket to the list of clients.
            m_clientSockets.Add(socket);
            // Say a client has connected.
            Console.WriteLine("Client connected!");
            // How many clients are connected? If it's less than 8, accept more.
            if (m_clientSockets.Count < 8) m_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            // Otherwise, no more players can enter the game. Don't accept more.
    	}
       
    	private void ReceiveCallback(IAsyncResult AR)
    	{
    		// Get the socket that is sending information to the server.
    		Socket socket = (Socket)AR.AsyncState;
    		try
    		{
				int bytesReceived = socket.EndReceive(AR);
	    		byte[] dataBuffer = new byte[bytesReceived];
	    		// Transfer what is in the server's buffer to this new dataBuffer.
	    		Array.Copy(m_buffer, dataBuffer, bytesReceived);
	    		// Convert the dataBuffer to a PlayerCommand struct.
	    		PlayerCommand command = GetStruct(dataBuffer);
	    		// Write a message to the console displaying what was sent.
	    		Console.WriteLine("Command received from " + command.Name);
	    		// Another switch statement! Yay!
	    		switch(command.Command)
	    		{
	    			case Command.Chat:
	    				// Send this message to all of the other players.
	    				SendToAll(dataBuffer);
	    				break;
                    case Command.Join:
                        // Process the join.
                        ProcessJoin(command.Name, ref socket);
                        break;
                    case Command.Roll:
                        // The player is taking their turn, so roll the dice.
                        Player turnTaker = m_game.GetPlayer(command.Name);
                        RollDice(ref turnTaker);
                        break;
                    case Command.Start:
                        // Process the start.
                        ProcessStart(dataBuffer, ref socket);
                        break;
                    case Command.Done:
                        // Process the next turn.
                        NextTurn();
                        break;
                    case Command.FundUpdate:
                        // Send the player their funds.
                        SendPlayerFunds(command.Name);
                        break;
                    case Command.BuyProperty:
                        // Perform the operations to buy a property.
                        Player buyer = m_game.GetPlayer(command.Name);
                        BuyPropertyActions(ref buyer);
                        // Send fund updates to the player.
                        SendPlayerFunds(command.Name);
                        break;
                    case Command.Mortgage:
                        // Perform the operations of mortgaging a property.
                        MortgageProperty(command.Name, command.Message);
                        // Send fund updates to the player.
                        SendPlayerFunds(command.Name);
                        break;
                    case Command.Unmortgage:
                        // Perform unmortgaging operations.
                        if (UnmortgageProperty(command.Name, command.Message))
                        {
                            // Indicate that the unmortgaging was a success to the player.
                            command.Name = "yes";
                        }
                        else
                        {
                            // Indicate that the unmortgaging was not a success.
                            command.Name = "no";
                        }
                        byte[] unmortgageResponse = GetBytes(command);
                        socket.BeginSend(unmortgageResponse, 0, unmortgageResponse.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                        break;
                    case Command.Jail:
                        // The player that went to jail now knows, so send position updates.
                        SendPositionUpdates();
                        break;
                    case Command.Card:
                        // The action on the card must now be performed.
                        DoCardActions(command.Name, command.Message);
                        break;
                    case Command.GetNames:
                        // Get the names of players still in the game.
                        SendPlayerNames(command.Name);
                        break;
                    case Command.GetProperties:
                        // Start getting the properties of the requested player.
                        SendProperties(command.Name, command.Message);
                        break;
                    case Command.GetFunds:
                        // Send the funds of a requested player and the player themselves.
                        SendTradeFunds(command.Name, command.Message);
                        break;
                    case Command.TradeRequest:
                        // Start processing a trade request.
                        DoTradeRequest(command.Name, command.Message);
                        break;
                    case Command.AcceptTrade:
                        // Start processing the trade.
                        ProcessTrade(command.Name, command.Message);
                        break;
                    case Command.DeclineTrade:
                        // Send a DeclineTrade command to the player in the message.
                        DeclinedTrade(command.Message);
                        break;
                    case Command.GetBuildingProperties:
                        // Start sending a list of eligible properties to build on.
                        SendPropertiesToBuildOn(command.Name);
                        break;
                    case Command.GetBuildingInfo:
                        // Start sending info about buildings on the property.
                        SendBuildingInfo(command.Name, command.Message);
                        break;
                    case Command.BuyBuilding:
                        // Buy a building.
                        BuyBuildingActions(command.Name, command.Message);
                        break;
                    case Command.SellBuilding:
                        // Sell a building.
                        SellBuildingActions(command.Name, command.Message);
                        break;
                    case Command.Bankrupt:
                        // Bankrupt the player.
                        BankruptPlayerActions(command.Name);
                        break;
	    			default:
	    				break;
	    		}
	    		// Start receiving again, but only if it's connected!
                if (socket.Connected) socket.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
    		catch(SocketException)
    		{
    			Console.WriteLine("Client disconnected.");
                // This player is out of the game. We will act like they were bankrupted and liquidated.
                // Before doing anything, look at the client sockets list. Is there only one player left?
                if (m_clientSockets.Count == 1)
                {
                    // Close the socket and remove them from the list.
                    socket.Close();
                    m_clientSockets.Remove(socket);
                    // Refresh the game.
                    m_game = new Game();
                    m_gameStarted = false;
                    Console.WriteLine("New game state has been started!");
                    return;
                }
                Player disconnectedPlayer = new Player();
                for (int i = 0; i < m_clientSockets.Count; i++)
                {
                    if (m_clientSockets[i] == socket)
                    {
                        // Get the player at this position.
                        disconnectedPlayer = m_game.GetPlayerAt(i);
                    }
                }
    			// Close the socket and remove them from the list.
    			socket.Close();
    			m_clientSockets.Remove(socket);
                // If the disconnectedPlayer's name is still "N/A," they already went bankrupt. Just return.
                if (disconnectedPlayer.Name == "N/A") return;
                // Send a chat message saying a player disconnected.
                PlayerCommand disconnecter = new PlayerCommand();
                disconnecter.Command = Command.Chat;
                disconnecter.Message = "(" + disconnectedPlayer.Name + " has disconnected from the server.)";
                byte[] disconnectBytes = GetBytes(disconnecter);
                SendToAll(disconnectBytes);
                // Bankrupt the player.
                BankruptPlayerActions(disconnectedPlayer.Name);
    		}
    	}
       
    	private void SendCallback(IAsyncResult AR)
    	{
    		try
    		{
    			Socket socket = (Socket)AR.AsyncState;
    			socket.EndSend(AR);
    		}
    		catch
    		{
    			Console.WriteLine("Error in SendCallback");
    		}
    	}
        // Sends an array of bytes to all of the clients connected to the server.
        private void SendToAll(byte[] a_buffer)
        {
            foreach (Socket connectedClient in m_clientSockets)
                connectedClient.BeginSend(a_buffer, 0, a_buffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), connectedClient);
        }
       
        private void ProcessJoin(string a_name, ref Socket a_socket)
        {
            // Create a response communication.
            PlayerCommand joinResponse = new PlayerCommand();
            // Has the game already started?
            if (m_gameStarted)
            {
                // If so, they cannot join the game. Boot them out.
                joinResponse.Command = Command.No;
                joinResponse.Message = "The game has already started.";
                byte[] startedBuffer = GetBytes(joinResponse);
                a_socket.BeginSend(startedBuffer, 0, startedBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), a_socket);
                a_socket.Close();
                m_clientSockets.Remove(a_socket);
            }
            // Does this player's name already exist in the game?
            else if (m_game.PlayerExistsInRoster(a_name))
            {
                // If so, they cannot join the game. Boot them out.
                joinResponse.Command = Command.No;
                joinResponse.Message = "The name you are trying to join with has already been taken.";
                byte[] noBuffer = GetBytes(joinResponse);
                a_socket.BeginSend(noBuffer, 0, noBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), a_socket);
                a_socket.Close();
                m_clientSockets.Remove(a_socket);
            }
            // Otherwise, go ahead and add them to the game. Send back a response indicating all went well, too.
            else
            {
                Player newPlayer = new Player(a_name, "default");
                m_game.AddPlayer(newPlayer);
                newPlayer.RosterPosition = m_clientSockets.Count - 1;
                joinResponse.Command = Command.Yes;
                byte[] yesBuffer = GetBytes(joinResponse);
                a_socket.BeginSend(yesBuffer, 0, yesBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), a_socket);
            }
        }
       
        private void ProcessStart(byte[] a_buffer, ref Socket a_socket)
        {
            // Initialize a PlayerCommand.
            PlayerCommand startResponse = new PlayerCommand();
            // Is there more than one player ready to play the game?
            if (m_clientSockets.Count > 1)
            {
                // If so, go ahead and start the game!
                // Stop accepting new connections, as the game is beginning.
                m_gameStarted = true;
                // Send a Start command to all of the clients. This turns off the Start Game button.
                SendToAll(a_buffer);
                // Now send a TurnStart command to the first socket that connected to the server. They are the first player.
                startResponse.Command = Command.TurnStart;
                byte[] startTurn = GetBytes(startResponse);
                m_clientSockets[0].Send(startTurn, 0, startTurn.Length, SocketFlags.None);
            }
            // Otherwise, send a message to the player trying to start the game to wait it out.
            else
            {
                startResponse.Command = Command.NoStart;
                byte[] noStartBuffer = GetBytes(startResponse);
                a_socket.BeginSend(noStartBuffer, 0, noStartBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), a_socket);
            }
        }
      
        private void RollDice(ref Player a_player)
        {
            // Initialize integers for the die roll and roll for them.
            int firstDie = 0, secondDie = 0;
            a_player.RollDice(ref firstDie, ref secondDie);
            // Send these die rolls to all the clients (everyone should see die rolls), along with the doubles count.
            PlayerCommand dieSender = new PlayerCommand();
            dieSender.Name = a_player.Name;
            dieSender.Command = Command.Roll;
            dieSender.Message = firstDie.ToString() + "," + secondDie.ToString() + "," + a_player.DoublesCount;
            byte[] dieBuffer = GetBytes(dieSender);
            SendToAll(dieBuffer);
            // Process the player's turn.
            DoTurn(ref a_player);
        }
        
        private void DoTurn(ref Player a_player)
        {
            // Do their turn.
            m_game.DoTurn(ref a_player);
            // Send position updates.
            SendPositionUpdates();
            // Did a player pass Go?
            if (a_player.PassedGo)
            {
                // Send fund updates.
                SendPlayerFunds(a_player.Name);
                // Correct the value.
                a_player.PassedGo = false;
                // Sleep a bit.
                System.Threading.Thread.Sleep(15);
            }
            // Evaluate the space.
            switch (m_game.EvaluateSpace(ref a_player))
            {
                case "pay up":
                    // Pay up the rent, as it is owed.
                    RentActions(ref a_player);
                    break;
                case "wanna buy":
                    // Ask if the player wants to buy a property.
                    AskToBuyProperty(a_player);
                    break;
                case "income tax":
                    // The player must pay a tax for landing on the space.
                    PayTax(a_player, "income tax");
                    break;
                case "luxury tax":
                    // The player must pay a tax for landing on the space.
                    PayTax(a_player, "luxury tax");
                    break;
                case "jail":
                    // The player was sent to jail.
                    WentToJail(a_player);
                    break;
                case "chance":
                    // Draw a Chance card.
                    Card drawnChance = m_game.DrawCard(ref a_player, "Chance");
                    // Send the info.
                    SendCardInfo(a_player, drawnChance.Action, drawnChance.Description);
                    break;
                case "community chest":
                    // Draw a Community Chest card.
                    Card drawnCommunity = m_game.DrawCard(ref a_player, "Community Chest");
                    // Send the info.
                    SendCardInfo(a_player, drawnCommunity.Action, drawnCommunity.Description);
                    break;
                default:
                    break;
            }
            // Perform bankruptcy checks.
            string bankruptcyCheckResult = m_game.BankruptcyCheck();
            // Someone is bankrupt if the result from the function is not null.
            if (bankruptcyCheckResult != "null")
            {
                // Get this player and send them a BankruptWarning.
                // Sleep to prevent a connection error.
                System.Threading.Thread.Sleep(20);
                Player bankruptPlayer = m_game.GetPlayer(bankruptcyCheckResult);
                PlayerCommand bankruptSender = new PlayerCommand();
                bankruptSender.Command = Command.BankruptWarning;
                byte[] bankruptBytes = GetBytes(bankruptSender);
                m_clientSockets[bankruptPlayer.RosterPosition].BeginSend(bankruptBytes, 0, bankruptBytes.Length, SocketFlags.None,
                    new AsyncCallback(SendCallback), null);
            }
        }
      
        private void RentActions(ref Player a_player)
        {
            // Pay up the rent, as it is owed.
            int rentOwed = m_game.CalculateRent(m_game.GetSpacePlayerIsOn(a_player), a_player.DieRoll);
            // Generate different message box dialogs for rent owed and rent received.
            string rentOwedDialog = m_game.GetSpacePlayerIsOn(a_player).GetProperty().Owner.Name + " owns " + m_game.GetSpacePlayerIsOn(a_player).GetProperty().Name +
            ". Rent owed is $" + rentOwed.ToString() + ".";
            string rentReceivedDialog = a_player.Name + " landed on " + m_game.GetSpacePlayerIsOn(a_player).GetProperty().Name + ". You receive $" +
            rentOwed.ToString() + "!";
            // Exchange funds.
            Player owner = m_game.GetSpacePlayerIsOn(a_player).GetProperty().Owner;
            m_game.PayUp(rentOwed, ref a_player, ref owner);
            // Send the messages to the respective players.
            PlayerCommand rentSend = new PlayerCommand();
            rentSend.Name = "Rent Owed";
            rentSend.Command = Command.RentBox;
            rentSend.Message = rentOwedDialog;
            // Send this to the poor sap paying rent.
            byte[] rentOwedBuff = GetBytes(rentSend);
            m_clientSockets[a_player.RosterPosition].BeginSend(rentOwedBuff, 0, rentOwedBuff.Length, SocketFlags.None, new AsyncCallback(SendCallback),
                null);
            rentSend.Name = "Rent Received";
            rentSend.Message = rentReceivedDialog;
            // Send this to the one getting rich.
            byte[] rentReceivedBuff = GetBytes(rentSend);
            m_clientSockets[owner.RosterPosition].BeginSend(rentReceivedBuff, 0, rentReceivedBuff.Length, SocketFlags.None, new AsyncCallback(SendCallback),
                null);
            // Sleep for a little to avoid connection errors.
            System.Threading.Thread.Sleep(50);
        }
       
        /**/
        private void AskToBuyProperty(Player a_player)
        {
            // Get the property the player landed on and start generating the dialog box.
            Property propertyLandedOn = m_game.GetSpacePlayerIsOn(a_player).GetProperty();
            // Generate a PlayerCommand to communicate with the client.
            PlayerCommand wannaBuyCommand = new PlayerCommand();
            wannaBuyCommand.Name = propertyLandedOn.Name;
            wannaBuyCommand.Command = Command.BuyProperty;
            wannaBuyCommand.Message = "Nobody currently owns " + propertyLandedOn.Name + ".\nIt costs $" + propertyLandedOn.Price.ToString() + ". Would you like to buy it?";
            // Send this to the player on the space.
            byte[] wannaBuyBytes = GetBytes(wannaBuyCommand);
            m_clientSockets[a_player.RosterPosition].BeginSend(wannaBuyBytes, 0, wannaBuyBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback),
                null);
        }
        // Lets the player buy the property that the player is currently on.
        private void BuyPropertyActions(ref Player a_player)
        {
            // Get the property the player is on.
            Property spaceProperty = m_game.GetSpacePlayerIsOn(a_player).GetProperty();
            a_player.BuyProperty(ref spaceProperty);
        }
      
        private void MortgageProperty(string a_player, string a_property)
        {
            // Get the player, then call the MortgageProperty function on them.
            Player player = m_game.GetPlayer(a_player);
            // First, check to see if the property is able to be mortgaged. If the space the property has contains
            // at least one building, it cannot be mortgaged.
            if (m_game.GetSpaceWithProperty(a_property).BuildingAmount > 0)
            {
                // This cannot be mortgaged.
                PlayerCommand noMortgage = new PlayerCommand();
                noMortgage.Command = Command.Mortgage;
                noMortgage.Message = a_property;
                // Send the message.
                byte[] noMortgageBytes = GetBytes(noMortgage);
                m_clientSockets[player.RosterPosition].BeginSend(noMortgageBytes, 0, noMortgageBytes.Length, SocketFlags.None,
                    new AsyncCallback(SendCallback), null);
                return;
            }
            player.MortgageProperty(a_property);
        }
        // Unmortgages a property... ideally!
        private bool UnmortgageProperty(string a_player, string a_property)
        {
            // Get the player.
            Player player = m_game.GetPlayer(a_player);
            return player.UnmortgageProperty(a_property);
        }
      
        private void PayTax(Player a_player, string a_rentType)
        {
            // Generate a PlayerCommand to communicate with the client.
            PlayerCommand taxPay = new PlayerCommand();
            taxPay.Command = Command.Tax;
            // Change the name depending on Income Tax or Luxury Tax.
            if (a_rentType == "income tax") taxPay.Name = "income tax";
            else taxPay.Name = "luxury tax";
            // Send the command to the player.
            byte[] taxBytes = GetBytes(taxPay);
            m_clientSockets[a_player.RosterPosition].BeginSend(taxBytes, 0, taxBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
        // Informs the player that they were sent to jail.
        private void WentToJail(Player a_player)
        {
            // Generate a PlayerCommand.
            PlayerCommand sentToJail = new PlayerCommand();
            sentToJail.Command = Command.Jail;
            // Send the command over.
            byte[] jailBytes = GetBytes(sentToJail);
            m_clientSockets[a_player.RosterPosition].BeginSend(jailBytes, 0, jailBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
       
        private void SendCardInfo(Player a_player, string a_action, string a_description)
        {
            // Generate a PlayerCommand.
            PlayerCommand cardInfo = new PlayerCommand();
            cardInfo.Name = a_action;
            cardInfo.Command = Command.Card;
            cardInfo.Message = a_description;
            // Send the command over.
            byte[] cardBytes = GetBytes(cardInfo);
            m_clientSockets[a_player.RosterPosition].BeginSend(cardBytes, 0, cardBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            // Sleep for a little bit?
            System.Threading.Thread.Sleep(50);
        }
        
        private void DoCardActions(string a_player, string a_action)
        {
            // Get the player from the name.
            Player player = m_game.GetPlayer(a_player);
            // Perform the card action on them.
            m_game.PerformCardAction(ref player, a_action);
            // Some spaces need different follow ups.
            switch (a_action)
            {
                case "advanceIllinois":
                case "advanceStCharles":
                case "advanceUtility":
                case "advanceRailroad":
                case "goBack3":
                case "readingRailroad":
                case "boardwalk":
                // Send position updates.
                SendPositionUpdates();
                // Evaluate the space.
                switch (m_game.EvaluateSpace(ref player))
                {
                    case "pay up":
                        // Pay up the rent, as it is owed.
                        RentActions(ref player);
                        break;
                    case "wanna buy":
                        // Ask if the player wants to buy a property.
                        AskToBuyProperty(player);
                        break;
                    case "income tax":
                        // The player must pay a tax for landing on the space.
                        PayTax(player, "income tax");
                        break;
                    case "luxury tax":
                        // The player must pay a tax for landing on the space.
                        PayTax(player, "luxury tax");
                        break;
                    case "chance":
                        // Draw a Chance card.
                        Card drawnChance = m_game.DrawCard(ref player, "Chance");
                        // Send the info.
                        SendCardInfo(player, drawnChance.Action, drawnChance.Description);
                        break;
                    case "community chest":
                        // Draw a Community Chest card.
                        Card drawnCommunity = m_game.DrawCard(ref player, "Community Chest");
                        // Send the info.
                        SendCardInfo(player, drawnCommunity.Action, drawnCommunity.Description);
                        break;
                    default:
                        break;
                }
                break;

                case "advanceGo":
                    // Send position updates and fund updates to the player.
                    SendPositionUpdates();
                    SendPlayerFunds(a_player);
                    break;

                case "jail":
                    // Send position updates.
                    SendPositionUpdates();
                    break;

                case "bankDividend":
                case "generalRepairs":
                case "poorTax":
                case "matures":
                case "bankError":
                case "doctorsFee":
                case "stockSale":
                case "xmasFund":
                case "taxRefund":
                case "lifeInsurance":
                case "hospitalFees":
                case "schoolTax":
                case "services":
                case "streetRepairs":
                case "beautyContest":
                case "inherit100":
                    // Send fund updates to the player.
                    SendPlayerFunds(a_player);
                    break;

                case "chairman":
                case "grandOpera":
                    // Send fund updates to everyone.
                    List<string> playerList = m_game.GetPlayers();
                    foreach (string name in playerList)
                    {
                        SendPlayerFunds(name);
                    }
                    break;

                default:
                    break;
            }
            // Perform bankruptcy checks.
            string bankruptcyCheckResult = m_game.BankruptcyCheck();
            // Someone is bankrupt if the result from the function is not null.
            if (bankruptcyCheckResult != "null")
            {
                // Get this player and send them a BankruptWarning.
                Player bankruptPlayer = m_game.GetPlayer(bankruptcyCheckResult);
                PlayerCommand bankruptSender = new PlayerCommand();
                bankruptSender.Command = Command.BankruptWarning;
                byte[] bankruptBytes = GetBytes(bankruptSender);
                m_clientSockets[bankruptPlayer.RosterPosition].BeginSend(bankruptBytes, 0, bankruptBytes.Length, SocketFlags.None,
                    new AsyncCallback(SendCallback), null);
            }
        }
        // Processes a Done command received from a player and shifts control to the next player to take their turn.
        private void NextTurn()
        {
            // Increment the player position.
            m_game.PlayerPosition = m_game.PlayerPosition + 1;
            // Reset this position if it's the same number as the amount of players still playing (not bankrupt).
            if (m_game.PlayersStillPlaying == m_game.PlayerPosition) m_game.PlayerPosition = 0;
            // Send a TurnStart command to this player.
            PlayerCommand turn = new PlayerCommand();
            turn.Command = Command.TurnStart;
            byte[] startTurn = GetBytes(turn);
            m_clientSockets[m_game.GetPlayerAt(m_game.PlayerPosition).RosterPosition].Send(startTurn, 0, startTurn.Length, SocketFlags.None);
        }
        // Sends the board position of all players.
        private void SendPositionUpdates()
        {
            // Send the position updates.
            PlayerCommand posUpdate = new PlayerCommand();
            posUpdate.Command = Command.PositionUpdate;
            posUpdate.Message = m_game.GetPositions();
            // Convert to a byte array and send it to everyone.
            byte[] posBytes = GetBytes(posUpdate);
            // Apparently a sleep is necessary to prevent the client programs from blowing up... let's just make it quick.
            System.Threading.Thread.Sleep(50);
            SendToAll(posBytes);
        }
        // Sends the amount of funds the player currently has to the player.
        private void SendPlayerFunds(string a_name)
        {
            // Get the player.
            Player requester = m_game.GetPlayer(a_name);
            // Get their funds.
            int funds = requester.Funds;
            // Send it over.
            PlayerCommand fundSend = new PlayerCommand();
            fundSend.Command = Command.FundUpdate;
            fundSend.Message = funds.ToString();
            byte[] fundBytes = GetBytes(fundSend);
            m_clientSockets[requester.RosterPosition].BeginSend(fundBytes, 0, fundBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
       
        private void SendPlayerNames(string a_name)
        {
            // Get the player requesting the list.
            Player requester = m_game.GetPlayer(a_name);
            // Get a list of the players.
            List<string> playerList = m_game.GetPlayers();
            // Start a string list to send over.
            string sendingList = "";
            foreach (string name in playerList)
            {
                // If the name is not equal to a_name (the player requesting the list), add it to the string.
                if (name != a_name)
                {
                    // Append a beginning bracket, the name, and an end bracket.
                    sendingList = sendingList + name + ",";
                }
            }
            // Send over the list.
            PlayerCommand listSend = new PlayerCommand();
            listSend.Command = Command.GetNames;
            listSend.Message = sendingList;
            byte[] listBytes = GetBytes(listSend);
            m_clientSockets[requester.RosterPosition].BeginSend(listBytes, 0, listBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
       
        private void SendProperties(string a_requester, string a_requestedPlayer)
        {
            // Get the respective players.
            Player requester = m_game.GetPlayer(a_requester);
            Player requestedPlayer = m_game.GetPlayer(a_requestedPlayer);
            // Look at the player's properties.
            ArrayList properties = requestedPlayer.Properties;
            // Create a new list of eligible properties to send.
            List<string> propertiesToSend = new List<string>();
            foreach (Property property in properties)
            {
                // If this property is not mortgaged, keep checking.
                if (!property.IsMortgaged)
                {
                    // Do another check to see if all of the properties of that building type have no houses.
                    // If so, add it to the list. Otherwise, don't.
                    if (m_game.AllPropertiesHaveNoHouses(property.Color))
                    {
                        propertiesToSend.Add(property.Name);
                    }
                }
            }
            // Start sending these properties over.
            PlayerCommand propertySender = new PlayerCommand();
            propertySender.Command = Command.GetProperties;
            string propList = "";
            foreach (string property in propertiesToSend)
            {
                propList = propList + property + ",";
            }
            propertySender.Message = propList;
            byte[] propertyByte = GetBytes(propertySender);
            m_clientSockets[requester.RosterPosition].BeginSend(propertyByte, 0, propertyByte.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), null);
        }
       
        private void SendTradeFunds(string a_requester, string a_requestedPlayer)
        {
            // Get the respective players.
            Player requester = m_game.GetPlayer(a_requester);
            Player requestedPlayer = m_game.GetPlayer(a_requestedPlayer);
            // Get both of their funds.
            string requesterFunds = requester.Funds.ToString();
            string requestedPlayerFunds = requestedPlayer.Funds.ToString();
            // Separate with a comma and send over.
            string bothFunds = requesterFunds + "," + requestedPlayerFunds;
            PlayerCommand fundSender = new PlayerCommand();
            fundSender.Command = Command.GetFunds;
            fundSender.Message = bothFunds;
            byte[] fundBytes = GetBytes(fundSender);
            m_clientSockets[requester.RosterPosition].BeginSend(fundBytes, 0, fundBytes.Length, SocketFlags.None,
                 new AsyncCallback(SendCallback), null);
        }
     
        private void DoTradeRequest(string a_name, string a_message)
        {
            // Parse some necessary info:
            string[] tradeInfo = a_message.Split(',');
            // Get the player that the request will be sent to.
            Player requestedPlayer = m_game.GetPlayer(tradeInfo[2]);
            // Send the info just received to this player.
            PlayerCommand requestSender = new PlayerCommand();
            requestSender.Name = a_name;
            requestSender.Command = Command.TradeRequest;
            requestSender.Message = a_message;
            byte[] tradeBytes = GetBytes(requestSender);
            m_clientSockets[requestedPlayer.RosterPosition].BeginSend(tradeBytes, 0, tradeBytes.Length,
                SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
       
        private void ProcessTrade(string a_name, string a_tradeInfo)
        {
            // Parse the trade info.
            string[] tradeInfo = a_tradeInfo.Split(',');
            // Get players.
            Player requester = m_game.GetPlayer(tradeInfo[2]);
            Player requestedPlayer = m_game.GetPlayer(a_name);
            // Trade the original offered property, if there is one.
            if (tradeInfo[0] != "null")
            {
                // Take this property out of the requester's property list then add it to the requested player's.
                m_game.TradeProperty(ref requester, ref requestedPlayer, tradeInfo[0]);
            }
            // Transfer money if necessary.
            if (tradeInfo[1] != "null")
            {
                m_game.PayUp(Int32.Parse(tradeInfo[1]), ref requester, ref requestedPlayer);
            }
            // Trade the requested property, if there is one.
            if (tradeInfo[3] != "null")
            {
                // Take this property out of the requested player's property list then add it to the requester's.
                m_game.TradeProperty(ref requestedPlayer, ref requester, tradeInfo[3]);
            }
            // Transfer money if necessary.
            if (tradeInfo[4] != "null")
            {
                m_game.PayUp(Int32.Parse(tradeInfo[4]), ref requestedPlayer, ref requester);
            }

            // Trading is done! Send an AcceptTrade command to both players to indicate success and perform GUI changes on their end.
            PlayerCommand acceptSender = new PlayerCommand();
            acceptSender.Command = Command.AcceptTrade;
            // First, the requester:
            string tradedProperties = tradeInfo[0] + "," + tradeInfo[3];
            acceptSender.Message = tradedProperties;
            byte[] requesterBytes = GetBytes(acceptSender);
            m_clientSockets[requester.RosterPosition].BeginSend(requesterBytes, 0, requesterBytes.Length,
                SocketFlags.None, new AsyncCallback(SendCallback), null);
            // And now the requested:
            tradedProperties = tradeInfo[3] + "," + tradeInfo[0];
            acceptSender.Message = tradedProperties;
            byte[] requestedPlayerBytes = GetBytes(acceptSender);
            m_clientSockets[requestedPlayer.RosterPosition].BeginSend(requestedPlayerBytes, 0, requestedPlayerBytes.Length,
                SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
        // Informs the player requesting a trade that their request was denied.
        private void DeclinedTrade(string a_name)
        {
            // Get the player who initially offered.
            Player requester = m_game.GetPlayer(a_name);
            // Send a DeclineTrade command to them.
            PlayerCommand declineSender = new PlayerCommand();
            declineSender.Command = Command.DeclineTrade;
            byte[] declineBytes = GetBytes(declineSender);
            m_clientSockets[requester.RosterPosition].BeginSend(declineBytes, 0, declineBytes.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), null);
        }
       
        private void SendPropertiesToBuildOn(string a_name)
        {
            // Get the list of properties.
            List<string> propertyList = m_game.GetPropertiesToBuildOn(a_name);
            // Build a comma separated string and then send it to the client requesting the list.
            string commaSeparatedProperties = "";
            foreach (string property in propertyList)
            {
                commaSeparatedProperties = commaSeparatedProperties + property + ",";
            }
            PlayerCommand propertySender = new PlayerCommand();
            propertySender.Command = Command.GetBuildingProperties;
            propertySender.Message = commaSeparatedProperties;
            byte[] propertyBytes = GetBytes(propertySender);
            m_clientSockets[m_game.GetPlayer(a_name).RosterPosition].BeginSend(propertyBytes, 0, propertyBytes.Length,
                SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
      
        private void SendBuildingInfo(string a_name, string a_propertyName)
        {
            // Get the property and the space that contains the propery.
            Space propertySpace = m_game.GetSpaceWithProperty(a_propertyName);
            Property property = propertySpace.GetProperty();
            // Get the amount of buildings on the space and the cost of buildings for the property, then send the info over.
            int buildingAmount = propertySpace.BuildingAmount;
            int buildingCost = property.BuildingCost;
            // Build a separated list and send it over.
            string numbersList = buildingAmount.ToString() + "," + buildingCost.ToString();
            PlayerCommand buildingSender = new PlayerCommand();
            buildingSender.Command = Command.GetBuildingInfo;
            buildingSender.Message = numbersList;
            byte[] buildingBytes = GetBytes(buildingSender);
            m_clientSockets[m_game.GetPlayer(a_name).RosterPosition].BeginSend(buildingBytes, 0, buildingBytes.Length,
                SocketFlags.None, new AsyncCallback(SendCallback), null);
        }
        
        private void BuyBuildingActions(string a_name, string a_propertyName)
        {
            // Get the player.
            Player player = m_game.GetPlayer(a_name);
            // Get the space.
            Space space = m_game.GetSpaceWithProperty(a_propertyName);
            // First, determine if the player has sufficient funds for a building.
            if (player.Funds < space.GetProperty().BuildingCost)
            {
                // Send a BuyBuilding command back to indicate you cannot build a building because of funds.
                PlayerCommand noBuySender = new PlayerCommand();
                noBuySender.Command = Command.BuyBuilding;
                noBuySender.Message = a_propertyName;
                byte[] noBuyBytes = GetBytes(noBuySender);
                m_clientSockets[player.RosterPosition].BeginSend(noBuyBytes, 0, noBuyBytes.Length, SocketFlags.None,
                    new AsyncCallback(SendCallback), null);
            }
            else
            {
                // Add a building to this space and subtract the building cost.
                space.AddBuilding();
                player.Funds = player.Funds - space.GetProperty().BuildingCost;
                // Send a fund update.
                SendPlayerFunds(a_name);
            }

        }
        // Sells a building on the property requested, then sends a fund update.
        private void SellBuildingActions(string a_name, string a_propertyName)
        {
            // Get the player.
            Player player = m_game.GetPlayer(a_name);
            // Get the space.
            Space space = m_game.GetSpaceWithProperty(a_propertyName);
            // No checks necessary, just remove the building and add funds.
            space.RemoveBuilding();
            player.Funds = player.Funds + (space.GetProperty().BuildingCost / 2);
            // Send a fund update.
            SendPlayerFunds(a_name);
        }
      
        private void BankruptPlayerActions(string a_name)
        {
            // This player is declaring bankruptcy. Get rid of any assets they may have.
            Player bankruptPlayer = m_game.GetPlayer(a_name);
            m_game.LiquidateAndBankrupt(ref bankruptPlayer);
            // Now check the game's player roster. Is there only 1 player left?
            List<string> remainingPlayers = m_game.GetPlayers();
            if (remainingPlayers.Count == 1)
            {
                // All other players are bankrupt. This player has won the game!
                // Send this message to everyone.
                PlayerCommand winSend = new PlayerCommand();
                winSend.Name = remainingPlayers[0];
                winSend.Command = Command.Winner;
                byte[] winBytes = GetBytes(winSend);
                foreach(Socket socket in m_clientSockets)
                {
                    socket.BeginSend(winBytes, 0, winBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback),
                        null);
                }
            }
        }

    	// The server's socket.
    	private Socket m_serverSocket;
    	// The list of clients.
    	private List<Socket> m_clientSockets;
    	// The buffer that the server will use for communication between clients.
    	private byte[] m_buffer = new byte[1024];
    	// The game to play on the server.
    	private Game m_game;
        // Boolean that determines whether or not the game has started.
        private bool m_gameStarted;
    }
}