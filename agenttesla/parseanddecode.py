from PIL import Image
import sys

def decode(P1):

	K1 = b"wc1"	# hard-coded in original binary

	# 0 119 0 
	# they're actually only using 0 119 0 because of how the K1 byte
	# array is initialised. Is that intentional??
	k = [0, 119, 0]

	# calc first XOR key, using hard-coded 112
	num = int(P1[-1] ^ 112)
	
	# initialise counters etc
	myArray = [0] * len(P1)
	num2 = len(P1) - 1 

	# loop over each byte and XOR with two keys
	# num is the hardcoded last byte of P1 XOR with 112
	# k[..] cycles through 0, 119 or 0
	for i in range (0, num2):
		myArray[i] = (P1[i] ^ num ^ k[i % len(k)])

	# return decoded array of ints
	return myArray

def imparse(imageFile):

	# load the image
	im = Image.open(imageFile)
	width, height = im.size

	# initialise counters and return array "b"
	num = 0
	num2 = width * width * 4
	num3 = width - 1
	b = [0] * (num2 - 1)
	
	# loop thru pixels
	# reorder the output from RGBA to ARGB
	for i in range (num3):
		for j in range (num3):
			R,G,B,A = im.getpixel((i,j))	
			b[num * 4 + 3] = A # A
			b[num * 4 + 2] = R # R
			b[num * 4 + 1] = G # G
			b[num * 4 + 0] = B # B
			num += 1

	# remove trailing 0's
	while b[-1] == 0:
		del b[-1]

	# strip first four bytes and return
	return b[4:]

def main():

	# take input from command line
	INPUTFILE = sys.argv[1]
	
	# parse the resource and extract pixel bytes
	pixelBytes = imparse(INPUTFILE)

	# decode the pixel bytes
	decoded = decode(pixelBytes)
	print (decoded)	

if __name__ == "__main__":
	main()