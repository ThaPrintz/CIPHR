/*CIPHR server web api*/

const CSOCKENUMS = Object.freeze({"TCPSOCK":0, "UDPSOCK":1, "IPV4SOCK":2, "IPV6SOCK":3, "WEBSOCK":4});

const csocket = function(csockdata)
{
	const { Socket } = require("net");
	
	this.address = csockdata.host;
	this.port	 = csockdata.portnum;
	this.dataprt = csockdata.dprtcl;
	this.ipprt 	 = csockdata.ipprtcl;
	
	this.sock    = new Socket();
}	

csocket.prototype.Connect = function()
{
	this.sock.connect(this.port, this.address, () =>{
		console.log("show no love to homo thugs");
	})
}

csocket.prototype.Write = function(strMsg)
{
	this.sock.write(strMsg);
}