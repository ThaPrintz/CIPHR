#include "rsc.h"

DWORD WINAPI _process(LPVOID arg);

int main()
{
	csockdata _config;
	_config.address				= "0.0.0.0";
	_config.port					= "70";
	_config.dataprotocol	= TCPSOCK;
	_config.ipprotocol		= IPV4SOCK;

	webxlib::csocket* _svmaster = new webxlib::csocket(&_config);

	if (_svmaster->Bind() != CSOCKET_SUCCESS)
		printf("master socket bind failure!\n");

	if (_svmaster->Listen() != CSOCKET_SUCCESS)
		printf("master socket Listen failure!\n");

	printf("CIPHR server listening\n");

	while (true) 
	{
		if (!_svmaster->IsValid())
			break;

		if (_svmaster->SelectReadable({0,0}) > 0)  {
			webxlib::csocket* cl = _svmaster->Accept();

			if (cl->IsValid()) {
				CreateThread(NULL, NULL, _process, (LPVOID)cl, 0, NULL);
			} else {
				delete cl; 

				continue;
			}
		}
	}

	return NULL;
}

DWORD WINAPI _process(LPVOID arg)
{
	webxlib::csocket* cl = (webxlib::csocket*)arg;

	if (!cl->IsValid())
		return NULL;

	char buff[1501];
	ZeroMemory(buff, 1501);

	while (int got = cl->Recv(buff, 1500)) {
		if (got == CSOCKET_ERROR || strcmp(buff, "") == 0) {
			break;
		}

		printf("data recv'd %s\n", buff);
	}

	return NULL;
}