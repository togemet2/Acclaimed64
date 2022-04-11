# Acclaimed64

For whatever reason, Acclaim neglected to properly change the region in the header on their prototype cartridges, making them unbootable on flashcarts and emulators.
Flashcarts and emulators will usually look at the GUID in the ROM's header to guess the region, however, this check is completely ignored on official hardware.

This tool will fix the header and make these builds playable without the need for an official developer/prototype cartridge.
It supports the three major N64 ROM formats which are as follows:

Big Endian (.z64)
Little Endian (.n64)
Byte Swapped (.v64)
