import os
import sys



fn = sys.argv[1]
file = open(fn.split('/')[-1].split('.')[0] + "_parsed.trace",'w')

if os.path.exists(fn):
	with open(fn) as f:
	    for line in f:
	     	l = line.split(' ')
	     	if l[6] in ['T','N']:
	     		file.write(str(l[1]) + ' ' + str(l[6]) + ' ' + '\n') 

file.close()
