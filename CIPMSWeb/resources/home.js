/*----------------------------------------------------------------------------------------*/
document.observe('dom:loaded', function(){
	if ($('slideshow')) {
		var show = new SlideShow(0, $('slideshow'), $$('.slide'), 6);
	}
});
