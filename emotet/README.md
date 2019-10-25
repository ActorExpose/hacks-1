# Emotet

A quick script to dump the C2 config from an unpacked Emotet malware sample.

## Getting Started

You need to have an unpacked Emotet sample. Emotet tends to use a custom-packer, although it is at present (October 2019) straight forward to unpack using breakpoints on the return address from calls to VirtualAlloc.

Once you have unpacked the sample, you need to dump the .data section of the binary. The C2 config is hardcoded in this section and therefore it's a good idea to carve it out.

Once you've dumped the .data section, feed it as an arg to this script.

## Usage

Simply feed this script with the dumped .data section of your unpacked sample. 

```
$ python3 emotet_config.py your_data_dump.dmp
```

## Author

**Colin Hardy** - [@cybercdh](https://twitter.com/cybercdh)

## Acknowledgments

A freaking excellent blog on Emotet was written by [Fortinet](https://www.fortinet.com/blog/threat-research/deep-dive-into-emotet-malware.html) where they describe the config structure.

