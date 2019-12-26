ifeq ($(CSHARP_COMPILER),)
	CSHARP_COMPILER = mcs
endif

.PHONY: all
all: bin/clr/monocurl.exe

bin/clr/monocurl.exe: monocurl.cs
	mkdir -p bin/clr
	$(CSHARP_COMPILER) monocurl.cs -o $@

clean:
	rm -rf bin
