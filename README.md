# SynchronousTCPServerLibrary
Simple Synchronous TCP Server Library written in C#.
#Documentation

##startListening(int port, int backlog)
1. port - Port on which server should run.
2. backlog - Maximum number of permitted connections.<br>
Notes: Starts server in the same thread, in other words - everything that goes after this method wont be executed untill server is stoped. To avoid it - read below.

<br>

##startListeningInSeperateThread(int port, int backlog)
1. port - Port on which server should run.
2. backlog - Maximum number of permitted connections.<br>
Notes: Creates thread in which it listens for connestions.

<br>

##closeServer()
Notes: Closes server.

<br>

##send(Socket socket, string message)
1. socket - Socket aka client.
2. message - message that you want to send.

<br>

##sendln(Socket socket, string message)
1. socket - Socket aka client.
2. message - message that you want to send.<br>
Notes: Same as "send" but adds "new line" symbol at the end of the message.

<br>

##broadcast(string message)
1. message - message that you want to broadcast.<br>
Notes: Broadcasts message to all clients.

<br>

##broadcastln(string message)
1. message - message that you want to broadcast.<br>
Notes: Broadcasts message(with "new line" symbol) to all clients.

<br>

##kick(Socket socket)
1. socket - Disconnects socket(client) of ur choice.

<br>

##kickAll()
Note: Disconnects all sockets.

<br>

#Delegates
1.onConnect <br>
2.onDisconnect<br>
3.onDataReceive























