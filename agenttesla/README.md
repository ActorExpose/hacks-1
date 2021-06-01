# Agent Tesla Resource Parser / Decoder

Agent Tesla malware hides an embedded DLL file in an encrypted Resource disguised as a PNG. Using dnSpy it's possible to identify the image parsing routine and the decryption algorithm. This is my attempt at implementing these routines in Python for the purpose of dumping the Agent Tesla payload.

***[1st June 2021]*** - At present, the code appears to work, but not entirely. See details below.

## Files in this Repo Explained

```DebuggerDisplayAttribute```

This is the malicious resource file that we want to parse and decode. I extracted this from the parent executable [0b30c8bd37d51f2818ccba788c52dab3](https://www.virustotal.com/gui/file/acc6e87935368643d87179159fd49c31cb9ae2ad41472dc5f531612390fb6c6d/detection)

```unpacked.bin```

This is what the DebuggerDisplayAttribute file should decode to. This is a malicious DLL so please handle with caution.

```ImageBytesFromMalware```

The malware first parses the Resource as an image and extracts each Pixel into an array of bytes in the form ARGB. This is an extract of what that part of the parsing routine from the malware produces.

```ImageBytesFromMyCode```

Despite me thinking my Python implementation is correct, the Pixel bytes that this code extracts appears to work until about half way through the code where the pixels are just different. I can't explain this, other than to say my implementation may be flawed, or there is a difference between how .NET parses pixels from PNGs versus the [Python Pillow library](https://pillow.readthedocs.io/en/stable/).

```output.charcodes```

This what this Python code currently outputs. It's an array of Char-Codes which can easily be converted into a file, although I have also done that below.

```output.file```

A file of the output.charcodes. This should match unpacked.bin, but clearly it doesn't. Sad face.

```decryption.code.vb```

This is the extracted code from the malware that performs the image parsing and decryption of the PNG resource. This is the code that I basically tried to implement in Python.


```parseanddecode.py```

My implementation of the image parsing and XOR decoding routine in Python. I'm not a professional coder therefore there may be glaring mistakes in this. yolo. 

There was some great work on another Agent Tesla variant by [Palo Alto's Unit 42](https://unit42.paloaltonetworks.com/unit42-analyzing-various-layers-agentteslas-packing/) on which I based most of my code. Respect to them.

## Usage

```bash
python3 parseanddecode.py DebuggerDisplayAttribute
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss

## License
[MIT](https://choosealicense.com/licenses/mit/)