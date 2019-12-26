all:
	make -C src all

install: all
	mkdir -p $(DESTDIR)/usr/lib/monocurl
	cp src/bin/clr/monocurl.exe $(DESTDIR)/usr/lib/monocurl

clean:
	make -C src clean
