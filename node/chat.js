var net = require('net');

var chatServer = net.createServer();

chatServer.on('connection', function(client){
	client.write('hi!\n');
	client.on('data', function(data){
		console.log(data);		
	});	
});

chatServer.listen(9000);
