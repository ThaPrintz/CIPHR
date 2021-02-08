/*CIPHR server web api*/

const net = require('net');

const CSOCKENUMS = Object.freeze({"TCPSOCK":0, "UDPSOCK":1, "IPV4SOCK":2, "IPV6SOCK":3, "WEBSOCK":4});

function REG_csocket(host, portnum, dprtcl, ipprtcl)
{
	const _obj = {};
	_obj.address = host;
	_obj.port	 = portnum;
	_obj.dataprt = dprtcl;
	_obj.ipprt 	 = ipprtcl;
	_obj.sock    = new net.Socket();
	
}	