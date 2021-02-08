/*CIPHR server web api*/

const net = require('net');

const CSOCKENUMS = Object.freeze({"TCPSOCK":0, "UDPSOCK":1, "IPV4SOCK":2, "IPV6SOCK":3, "WEBSOCK":4});

function csocket(host, portnum, dprtcl, ipprtcl)
{
	this.address = host;
	this.port	 = portnum;
	this.dataprt = dprtcl;
	this.ipprt 	 = ipprtcl;
	this.sock    = new net.Socket();
	
	this.cConnect = function() {
		this.sock.connect(this.port, this.address, () =>{
			console.log("show no love to homo thugs");
		})
	}
}	