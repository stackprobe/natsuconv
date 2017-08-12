#include "C:\Factory\Common\all.h"
#include "C:\Factory\SubTools\libs\wav.h"

#define WAV_HZ 44100
#define WAV_SEC 3

int main(int argc, char **argv)
{
	autoList_t *wavData = newList();
	uint c;

	for(c = 0; c < WAV_HZ * WAV_SEC; c++)
	{
		addElement(wavData, 0x80008000);
	}
	writeWAVFile(getOutFile("muon.wav"), wavData, WAV_HZ);
	releaseAutoList(wavData);
	openOutDir();
}
