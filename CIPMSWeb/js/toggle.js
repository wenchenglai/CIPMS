var SummerOfFun = Class.create({
	initialize: function(container){
		this.container = $(container);
		this.contents = this.container.select('.map');
		this.points = this.container.select('.point');
		this.prevBtn = $('prev');
		this.nextBtn = $('next');
		
		this.initial = 0;
		this.dur = 0.5;
		this.showOnly(this.contents[this.initial]);
		this.current = this.initial;
		
		this.prevBtn.addClassName("inactive");
		this.prevBtn.observe('click', this.back.bind(this));
		this.nextBtn.observe('click', this.forward.bind(this));
		
		this.points.each(function(el) {
			new PopUp(el.down('.trigger'), el.down('.tooltip'));
		});	
	},
	showOnly: function(el){
		this.contents.invoke('hide');
		el.show();
	},
	goTo: function(idx, dur) {
		document.fire('pop:close');
		if(idx == this.current) {
		  return;
		}
		
		this.hide = new Effect.Fade(this.contents[this.current], { duration : dur || this.dur, afterFinish: function() {
			this.hide = null;
		}.bind(this)});
		
		this.current = idx;
		
		this.show = new Effect.Appear(this.contents[this.current],{duration: dur || this.dur, afterFinish:function() {
			this.show = null;
		}.bind(this)});
		
		if(this.current === 0) {
			this.prevBtn.addClassName("inactive");
		}
		else {
			this.prevBtn.removeClassName("inactive");
		}
		if(this.current == this.contents.length-1) {
			this.nextBtn.addClassName("inactive");
		}
		else {
			this.nextBtn.removeClassName("inactive");
		}
	},
	pause: function(){
		this.hide ? this.hide.cancel() : 0; 
		this.show ? this.show.cancel() : 0;
	},
	forward: function(ev){
		if (this.show || this.hide) {
		  return;
		}
		this.pause();
		this.next();
		ev.stop(); 
	},
	back: function(ev) {
		if(this.show || this.hide) {
		  return;
		}
		this.pause();
		
		if(this.current === 0) {
			return;
		}
		else {
			this.goTo(this.current-1);
		}
		ev.stop();
	},
	next: function() {
		if (this.current == this.contents.length-1) {
			return;
		}
		else {
			this.goTo(this.current+1);
		}
	}
});

document.observe('dom:loaded', function(){
	if($('map')) {
	  new SummerOfFun('map');
	}
});
