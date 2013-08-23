/* Tabs
----------------------------------------------------------------------------------------*/
var Tabs = Class.create({
	initialize: function(container, togglers, tabs, active) {
		this.container = $(container);
		this.togglers = $(togglers);
		this.tabs = $(tabs);
		this.active    = active || 0;
		this.setup();
	},
	setup: function() {
		this.tabs[this.active].addClassName('active');
		this.togglers[this.active].addClassName('active');
		this.togglers.each(function(el, i) {
			el.onclick = function() {
				if (i != this.active) {
					el.addClassName('active');
					this.togglers[this.active].removeClassName('active');
					
					if(this.tabs.length == this.togglers.length){
						this.tabs[this.active].removeClassName('active');
						this.tabs[i].addClassName('active');
					}
				}
				this.active = i;
				return false;
			}.bind(this);
		}.bind(this));
	}
});

/* SimpleToggler
----------------------------------------------------------------------------------------*/
var SimpleToggler = Class.create({
	initialize: function(trigger, content, options) {
		this.trigger = trigger;
		this.content = content;
		this.options = Object.extend({
			closeToggler: ''
		}, options);
		
		if(this.trigger && this.content)
			this.setup();
	},
	setup: function() {
		this.trigger.observe('click', this.toggler.bind(this));
		if(this.options.closeToggler != '') {
			this.extra_toggle = this.content.adjacent(this.options.closeToggler);
			this.extra_toggle[0].observe('click', this.toggler.bind(this));
		}
	},
	toggler: function(ev) {
		this.trigger.toggleClassName("active");
		if(this.extra_toggle) {
			this.extra_toggle[0].toggleClassName("active");
		}
		Effect.toggle(this.content, 'appear', { duration: 0.2 }); 
		if(ev) {
			ev.stop();
		}
	}
});

/* HoverDelay
----------------------------------------------------------------------------------------*/
var HoverDelay = Class.create({
	initialize : function(trigger, options){
		this.options = Object.extend({closeSelector : '.close', enterCb : function(){},	leaveCb : function(){},	delay : 0.5}, options || {});
		
		this.trigger = $(trigger);
		this.timeout = null; 
		this.active = false;
		this.setup();
		this.homeSlide = $('home_slide');
		this.modules = $('modules');
	},
	setup : function(){
		var eEvt = this.open.bindAsEventListener(this);
		var lEvt = this.close.bindAsEventListener(this);
		this.trigger.observe('mouseenter', eEvt);
		this.trigger.observe('mouseleave', lEvt);
		this.trigger.observe('hoverdelay:stop', function(){
			this.trigger.stopObserving('mouseenter', eEvt);
			this.trigger.stopObserving('mouseleave', lEvt);
		}.bind(this));
		document.observe('pop:active', function(){this.inactive=true;}.bind(this));
		document.observe('pop:inactive', function(){this.inactive=false;}.bind(this));
	}, 
	open : function(event){
		if (this.inactive) return;
		this.timeout = (function(){
			this.trigger.addClassName("active");
			this.options.enterCb.bind(this)();
			this.active = true;
		}).bind(this).delay(this.options.delay);
	},
	close : function(event){
		if (this.inactive) return;
		if (this.timeout) {
			window.clearTimeout(this.timeout);
			this.timeout = null;
		}
		if (this.active){
			this.options.leaveCb.bind(this)(event);
			this.active = false;
			this.trigger.removeClassName("active");
		}
	}
});

/* PopUp
----------------------------------------------------------------------------------------*/
var PopUp = Class.create({
	initialize : function(trigger, pop, options){
		this.trigger = trigger;
		this.pop = $(pop);
		
		this.options = Object.extend({
			modal:  false,
			centered: false,
			fade: false,
			closeSelector:  '.close',
			handleSelector: '.overlay_head'
		}, options || {});
		
		PopUp.i = 0;
		PopUp.open = false;		
		
		if(this.pop && this.trigger) {
			this.setup();
		}
	},
	setup : function(){
		//this.pop.hide();
		this.trigger.observe('click', this.open.bindAsEventListener(this));
	},
	open : function(ev){
		// allow only one popup opened at a time
		if (PopUp.open) { 
			PopUp.open.close(false); 
		}
		PopUp.open = this;
	
		document.fire("pop:active");
		this.toTop();
		if(this.trigger != $('btn_filter_search')){
			this.trigger.addClassName("active");
		}
		
		// close button(s)
		this.pop.select(this.options.closeSelector).each(function(el){
			el.observe('click', this.close.bind(this));
		}.bind(this));
		
		// draggable handle
		this.pop.select(this.options.handleSelector).each(function(el){
			this.draggable = new Draggable(this.pop, { handle: this.handle, starteffect: false, endeffect: false });
		}.bind(this));
		
		// close pop if user clicks anywhere in document
		this.close_listener = this.close.bindAsEventListener(this);
		Event.observe(document, 'click', this.close_listener);
		document.observe('pop:close',  this.close_listener);
		
		this.pop.observe('mouseenter', function() {
			Event.stopObserving(document, 'click', this.close_listener); 
		}.bind(this));

		this.pop.observe('mouseleave', function() {
			Event.observe(document, 'click', this.close_listener); 
		}.bind(this));
		
		// modal version
		if(this.options.modal) {
			this.initModalWindow('modal_overlay');
		}
		
		// centered version
		if(this.options.centered) {
			this.center();
		}

		// fade
		if(this.options.fade) {
			this.pop.appear({duration: 0.2});
		}
		// else just show
		else {
			//this.pop.show();
			this.pop.setStyle('display', 'block');
		}

		
		(this.options.onOpen || Prototype.emptyFunction)();

		if (typeof(ev) == 'object') {
			ev.stop();
		}
	},
	close : function(ev){
		//console.log(Event.findElement(ev, 'a'));
		/* removing, not sure what this fixed 
		if(Event.findElement(ev, 'a') == $$('a.close')[0] 
		    || Event.findElement(ev, 'a') == $$('a.close')[1]
		    || Event.findElement(ev, 'a') == $$('a.close')[2]
		    || Event.findElement(ev, 'a') == $$('a.close')[3]
		    || Event.findElement(ev, 'a') == $$('a.close')[4]){*/
			//alert('close');
			document.fire("pop:inactive");
			PopUp.open = false;
	
			this.trigger.removeClassName("active");
			if(this.options.modal) {
				$('modal_overlay').hide();
			}
			if(this.options.fade) {
				this.pop.fade({duration: 0.2});
			}
			else {
				this.pop.hide();				
				this.pop.setStyle('display', 'none');
			}
				
			Event.stopObserving(document, 'click', this.close_listener);
			document.stopObserving('pop:close',  this.close_listener);
			this.pop.stopObserving('mouseenter');
			this.pop.stopObserving('mouseleave');
			
			(this.options.onClose || Prototype.emptyFunction)();
			
			if (ev) {
				ev.stop();
			}
		//}
	},
	initModalWindow: function(el) {
		$(el).setStyle({
			height: $$('body').first().getHeight() + "px",
			zIndex: 100
		});
		$(el).show();
	},
	toTop: function() {
		PopUp.i += 1;
		this.pop.style.zIndex = PopUp.i + 1000;
		this.pop.show();
	},
	center: function() {
		if (this.hasBeenCentered) { 
			return;
		}
		var w, h, pw, ph;
		w = this.pop.offsetWidth;
		h = this.pop.offsetHeight;
		Position.prepare();
		var ws = this.getWindowSize();
		pw = ws[0];
		ph = ws[1];
		this.pop.setStyle({
			top: (ph/2) - (h/2) +  Position.deltaY + "px",
			left: (pw/2) - (w/2) +  Position.deltaX + "px"
		});
		this.hasBeenCentered = true;
	},
	getWindowSize: function(w) {
		w = w ? w : window;
		var width = w.innerWidth || (w.document.documentElement.clientWidth || w.document.body.clientWidth);
		var height = w.innerHeight || (w.document.documentElement.clientHeight || w.document.body.clientHeight);
		return [width, height];
	}
});

/* KickOut
----------------------------------------------------------------------------------------*/
var KickOut = Class.create(PopUp, {
	setup : function(){
		new HoverDelay(this.link, {
			delay   : 0.4,
			enterCb : this.open.bind(this),
			leaveCb : this.close.bind(this)
		});
	}
});

/* PromptHighlighter
----------------------------------------------------------------------------------------*/
var PromptHighlighter = Class.create({
	initialize: function(field) {
		this.field = $(field);
		this.setup();
	},
	setup: function() {
		this.field.observe('focus', this.focus.bind(this));
		this.field.observe('blur', this.blur.bind(this));
	},
	focus: function() {
		this.field.addClassName('active');
	},
	blur: function() {
		this.field.removeClassName('active')
	}
});

/* SlideShow
----------------------------------------------------------------------------------------*/
var SlideShow = Class.create({
	initialize : function(initial, container, contents, delay, options){
		this.initial = initial;
		this.container = container;
		this.contents = contents;
		this.delay = delay;
		this.fadeDuration = .8;
		this.showOnly(this.contents[this.initial]);
		this.current = initial;
		this.show = null; 
		this.hide = null;
		
		this.options = Object.extend({
			prevToggler: '.prev',
			nextToggler: '.next',
			btnToggler: '.controls li'
		}, options || {});
		
		if(this.container.select(this.options.prevToggler).length > 0 && this.container.select(this.options.nextToggler).length > 0) {
			this.prevBtn = this.container.select('.prev')[0];
			this.nextBtn = this.container.select('.next')[0];
			this.prevBtn.observe('click', this.back.bindAsEventListener(this));
			this.nextBtn.observe('click', this.forward.bindAsEventListener(this));
			
			//handle ie6's lack of hover support on non-anchor elements
			if(Prototype.Browser.IE6) {
				this.prevBtn.observe('mouseenter', function() { this.addClassName('hover_prev'); });
				this.prevBtn.observe('mouseleave', function() { this.removeClassName('hover_prev'); });
				this.nextBtn.observe('mouseenter', function() { this.addClassName('hover_next'); });
				this.nextBtn.observe('mouseleave', function() { this.removeClassName('hover_next'); });
			}
			
			if(this.contents.length <=1) {
				this.prevBtn.hide();
				this.nextBtn.hide();
			}
			else {
				this.start();
			}
		}
		if(this.container.select(this.options.btnToggler).length > 0) {
			this.buttons = this.container.select(this.options.btnToggler);
			this.buttons.each(function(el, i) {
				el.observe('click', (function(ev){
					ev.stop();
					this.pause();
					this.goTo(i, .5);
				}).bind(this));
			}.bind(this));
			
			this.buttons[this.current].addClassName('active');
			this.start();
		}
	},
	start : function(){
		if (this.timer) return;
		this.timer = setTimeout(this.next.bind(this), this.delay * 1000);
	},
	showOnly : function(el){
		this.contents.invoke('hide');
		el.show();
	},
	pause : function(){
		if (this.timer){
			clearTimeout(this.timer);
			this.timer = false;
		}
		this.hide ? this.hide.cancel() : 0; 
		this.show ? this.show.cancel() : 0;
	},
	back: function(ev){
		if (this.show || this.hide) return;
		this.pause(); 
		if (this.current == 0)
			this.goTo(this.contents.length-1);
		else
			this.goTo(this.current-1);
			
		ev.stop(); 
	},
	forward: function(ev){
		if (this.show || this.hide) return;
		this.pause();
		this.next();
		ev.stop(); 
	}, 
	next: function(){
		this.timer = false;
		if (this.current == this.contents.length-1)
			this.goTo(0);
		else
			this.goTo(this.current+1);
		this.start();
	},	
	goTo: function(idx, dur){
		if (idx == this.current) return;
		$(this.contents[this.current]).fade({ duration: .8, from: 1, to: 0 });

		if(this.buttons)
			this.buttons[this.current].removeClassName('active');
		
		this.current = idx;
		$(this.contents[this.current]).appear({ duration: .8, from: 0, to: 1 });
		if(this.buttons) {
			this.buttons[this.current].addClassName('active');
			this.start();
		}
	}
});


/* ShowMore
----------------------------------------------------------------------------------------*/
var ShowMore = Class.create({
	initialize : function(content, moreText, lessText) {
		this.content = content;
		this.moreText = moreText;
		this.lessText = lessText;
		//this.ellipsis = new Element('span', { 'class': 'ellipsis' }).update("... ");
		this.anchor = new Element('a', { href: "#", 'class': 'btn_moreinfo' });
		this.setup();
	},
	setup: function() {
		this.content.insert(this.ellipsis);
		this.content.insert(this.anchor);
		this.anchor.update(this.moreText);
		this.anchor.observe('click', this.toggler.bind(this));
	},
	toggler: function(ev) {
		this.anchor.previous(".more").toggleClassName("active");
		this.anchor.innerHTML = (this.anchor.innerHTML == this.moreText) ? this.lessText : this.moreText;
		this.anchor.toggleClassName("active");
		//this.ellipsis.innerHTML = (this.anchor.innerHTML == this.moreText) ? "... " : "";
		ev.stop();
	}
});

/* Navigation
----------------------------------------------------------------------------------------*/
var Navigation = Class.create({
	initialize: function(container) {
		this.container = $(container);
		this.togglers = this.container.select('li.menu');
		this.menus = this.container.select('.overlay');
		
		this.setup();
	},
	setup: function(){
		this.togglers.each(function(el, i) {
			new HoverDelay(el,{
				delay   : 0.4,
				enterCb: this.show.bindAsEventListener(this, i),
				leaveCb: this.hide.bindAsEventListener(this, i)
			});
		}.bind(this));
	},
	show: function(ev, i) {
		new Effect.SlideDown(this.menus[i], { duration: .2});
		if(ev) ev.stop();
	},
	hide: function(ev, i) {
		new Effect.SlideUp(this.menus[i], { duration: .2});
		if(ev) ev.stop();
	}
});

/* ExternalLinks
----------------------------------------------------------------------------------------*/
var ExternalLinks = Class.create({
	initialize: function(selector) {
		this.container = $$('body').first();
		this.selectors = this.container.select(selector);
		this.setup();
	},
	setup: function() {
		this.selectors.each(function(el) {
			if(el.getAttribute("href") && el.getAttribute("rel") == "external") {
				el.observe('click', function() {
					window.open(this.href);
					
				});
			}
		});
	}
});

/* RemoveEmptyTags
----------------------------------------------------------------------------------------*/
var RemoveEmptyTags = Class.create({
	initialize: function(selector) {
		this.container = $$('body').first();
		this.selectors = this.container.select(selector);
		this.setup();
	},
	setup: function() {
		this.selectors.each(function(el) {
			if(el.innerHTML == '' || el.innerHTML == '&nbsp;') {
				el.remove();
			}
		});
	}
});

/*----------------------------------------------------------------------------------------*/
document.observe('dom:loaded', function(){
	try {
	  document.execCommand('BackgroundImageCache', false, true);
	} catch(e) {}
	
	
	if($('nav_main')) {
		var navigation = new Navigation('nav_main');
	}
	
	//var externalLinks = new ExternalLinks('a');
	var emptyTags = new RemoveEmptyTags('p');
});
