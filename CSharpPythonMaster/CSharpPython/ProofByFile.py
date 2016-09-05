import os
import sys

scriptpath = os.path.dirname(os.path.realpath(__file__))
filename = os.path.join(scriptpath, sys.argv[1])
print(filename)
file = open(filename, "w")
file.write("She came from Greece. She had a third for knowledge.")
file.close()
