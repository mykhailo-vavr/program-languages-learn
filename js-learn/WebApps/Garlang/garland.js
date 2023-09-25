class Garland {
  constructor(options) {
    this.options = options;
  }

  start() {
    this.checkOptions();
    this.createGarland();
  }

  checkOptions() {
    let opts = this.options;
    opts.colors = opts.colors || ['#fff'];
    opts.count = opts.count || 0;
    opts.container = opts.container || document;
    opts.flashingSpeed = opts.flashingSpeed || 1000;
  }

  createGarland() {
    this.garland = document.createElement('div');
    this.garland.classList.add('garland');
    this.options.container.append(this.garland);
    this.fillWithBulbs();
  }

  fillWithBulbs() {
    let count = this.options.count;
    let colors = this.options.colors;

    for (let i = 0; i < count; i++) {
      let color = colors[i % colors.length];
      this.createBulb(color);
    }
  }

  createBulb(color) {
    let bulb = document.createElement('div');
    bulb.classList.add('garland-bulb');
    this.setEffects(bulb, color);
    this.garland.append(bulb);
  }

  setEffects(bulb, color) {
    bulb.style.cssText = `
      background: ${color};
      color: ${color};
      animation-duration: ${(this.options.flashingSpeed || 1000) / 1000}s;`;
  }
}

let garland = new Garland({
  count: 15,
  flashingSpeed: 7000,
  colors: ['#9C2F35', '#C39322', '#56C1D0', 'red', 'green', '#ccc'],
  container: document.querySelector('.container'),
});

garland.start();
