/*****************************************************************************
It is adviced to place the sIFR JavaScript calls in this file, keeping it
separate from the `sifr.js` file. That way, you can easily swap the `sifr.js`
file for a new version, while keeping the configuration.

You must load this file *after* loading `sifr.js`.

That said, you're of course free to merge the JavaScript files. Just make sure
the copyright statement in `sifr.js` is kept intact.
*****************************************************************************/

// Make an object pointing to the location of the Flash movie on your web server.
// Try using the font name as the variable name, makes it easy to remember which
// object you're using. As an example in this file, we'll use Futura.

// NOTE: meta_bold is now defined in the base.html template.
// var meta_bold = { src: '/flash/meta_bold.swf' };

// Now you can set some configuration settings.
// See also <http://wiki.novemberborn.net/sifr3/JavaScript+Configuration>.
// One setting you probably want to use is `sIFR.useStyleCheck`. Before you do that,
// read <http://wiki.novemberborn.net/sifr3/DetectingCSSLoad>.

// sIFR.useStyleCheck = true;

// Next, activate sIFR:
sIFR.activate(meta_bold);

// If you want, you can use multiple movies, like so:
//
//    var futura = { src: '/path/to/futura.swf' };
//    var garamond = { src '/path/to/garamond.swf' };
//    var rockwell = { src: '/path/to/rockwell.swf' };
//    
//    sIFR.activate(futura, garamond, rockwell);
//
// Remember, there must be *only one* `sIFR.activate()`!

// Now we can do the replacements. You can do as many as you like, but just
// as an example, we'll replace all `<h1>` elements with the Futura movie.
// 
// The first argument to `sIFR.replace` is the `futura` object we created earlier.
// The second argument is another object, on which you can specify a number of
// parameters or "keyword arguemnts". For the full list, see "Keyword arguments"
// under `replace(kwargs, mergeKwargs)` at 
// <http://wiki.novemberborn.net/sifr3/JavaScript+Methods>.
// 
// The first argument you see here is `selector`, which is a normal CSS selector.
// That means you can also do things like '#content h1' or 'h1.title'.
//
// The second argument determines what the Flash text looks like. The main text
// is styled via the `.sIFR-root` class. Here we've specified `background-color`
// of the entire Flash movie to be a light grey, and the `color` of the text to
// be red. Read more about styling at <http://wiki.novemberborn.net/sifr3/Styling>.
sIFR.replace(meta_bold, {
	selector: 'h1.sifr',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 41px; color: #5e5046; leading: -7 }'
});

/*
sIFR.replace(meta_bold, {
	selector: 'h1.sifr_landing',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 70px; color: #39c0c3; leading: -6 }'
});
*/

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_header',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 33px; color: #5e5046; leading: -1 }'
});

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_header_medium',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 28px; color: #5e5046; leading: -1 }'
});

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_header_medium_two_line',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 29px; color: #5e5046; leading: -1 }'
});

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_header_small',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 26px; color: #5e5046; leading: -1 }'
});

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_header_small_two_line',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 26px; color: #5e5046; leading: -1 }'
});

sIFR.replace(meta_bold, {
	selector: 'h1.sifr_camps',
	wmode: 'transparent',
	ratios: [7, 1.32, 9, 1.24, 13, 1.25, 16, 1.21, 22, 1.2, 23, 1.17, 25, 1.19, 27, 1.17, 32, 1.16, 33, 1.17, 42, 1.16, 47, 1.15, 48, 1.16, 58, 1.15, 59, 1.14, 63, 1.15, 64, 1.14, 65, 1.15, 71, 1.14, 72, 1.15, 103, 1.14, 104, 1.13, 110, 1.14, 112, 1.13, 115, 1.14, 119, 1.13, 121, 1.14, 1.13],
	css: '.sIFR-root { font-size: 31px; color: #5e5046; leading: -1 }'
});
