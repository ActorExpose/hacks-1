'''
  emotet_config.py
  written by @cybercdh

  requirements:
  you need to unpack the Emotet sample first.
  to do this, break point on the return from VirtualAlloc and when data 
  is written to the buffer in EAX, jump to user code and dump the buffer at EDI+54.
  this will contain the unpacked binary, with some noise atop the code which you
  will need to remove manually.
  then, dump the .data section of this unpacked version (using x64dbg).
  feed this .data dump to this script.
  then...profit.
  
'''
import re
import argparse

def hunt(data):
  # the pattern looks for common ports associated with Emotet C2s
  # 01BB = 443
  # 1F90 = 8080
  # 0050 = 80
  # 1BA8 = 7080
  # remember - little endian...
  p = re.compile(b"(....(\xbb\x01|\x90\x1f|\x50\x00|\xa8\x1b))")
  
  # iterate through the dump and look for matches. 
  # note the start and end location of the matching groups.
  # we assume that the config will start with the first match and end at the last.
  # because of this assumption, some C2's may get missed, no guarantees.
  ranges = []
  for m in p.finditer(data):
    ranges.append(m.start())
  
  ranges.sort()

  configStart = ranges[0]
  configEnd = ranges[-1] + 8 # +8 to ensure we include the final block of bytes.

  # carve the suspected config bytes from the stream of 'data' bytes
  config = data[configStart:configEnd]

  # iterate over the config bytes in chunks of 8.
  # for each chunk of 8, the first four bytes are the IP, bytes [4] and [5] are the port.
  # bytes [6] and [7] are ignored.
  for c2 in [config[i:i+8] for i in range(0, len(config), 8)]: 
    ip = []
    ip.append(c2[3])
    ip.append(c2[2])
    ip.append(c2[1])
    ip.append(c2[0]) 

    # i stole the syntax in the next two lines from Stack Overflow. Long live SO.
    # it joins the ip list nicely and combines the two bytes together for the port number.
    ip_string = '.'.join(str(v) for v in ip)
    port=(c2[5]<<8)|(c2[4]) 

    # print nicely to the terminal, allowing for piping to other tools.
    print("{}:{}".format(ip_string, port))

def main(dump):
  try:
    # open the file in binary mode and go hunting for the config
    f = open(dump, 'rb')
    data = f.read()
    f.close()
    hunt(data)
  except Exception as e:
    print("[!]  An error occurred {}".format(e))


if __name__ == '__main__':
  parser = argparse.ArgumentParser(description='Attempt to find the Emotet C2 config from a dumped .data section')
  parser.add_argument('dump', help='This should be a .data section output from an unpacked Emotet sample')
  args = parser.parse_args()

  main(args.dump)