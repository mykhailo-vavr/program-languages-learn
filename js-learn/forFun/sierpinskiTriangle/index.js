class View {
  constructor() {
    this.container = document.querySelector('.container');
  }

  createDot(left, top, index) {
    let colors = [
      '#9c88ff',
      '#4cd137',
      '#487eb0',
      '#e84118',
      '#192a56',
      '#7f8fa6'
    ];
    let dot = document.createElement('div');
    dot.classList.add('dot');
    dot.style.background = colors[index];
    dot.style.left = `${left}px`;
    dot.style.top = `${top}px`;
    this.container.append(dot);
    return dot;
  }
}

class Model {
  constructor(view) {
    this.view = view;
    this.coords = {
      a: { x: 400, y: 80 },
      b: { x: 200, y: 400 },
      c: { x: 600, y: 500 }
    };

    let cs = this.coords;
    this.dotA = this.view.createDot(cs.a.x, cs.a.y, 0);
    this.dotB = this.view.createDot(cs.b.x, cs.b.y, 1);
    this.dotC = this.view.createDot(cs.c.x, cs.c.y, 2);
    this.currentDot = this.view.createDot(330, 300, 3);
    this.start();
  }

  start() {
    setInterval(() => {
      const number = this.getRandom(1, 6);
      let left, top;

      if (number <= 2) {
        left = this.coords.a.x;
        top = this.coords.a.y;
      } else if (number >= 5) {
        left = this.coords.b.x;
        top = this.coords.b.y;
      } else {
        left = this.coords.c.x;
        top = this.coords.c.y;
      }

      left = (left + parseInt(this.currentDot.style.left)) / 2;
      top = (top + parseInt(this.currentDot.style.top)) / 2;
      this.currentDot = this.view.createDot(
        left,
        top,
        this.getRandom(0, 5)
      );
    }, 10);
  }

  getRandom(min, max) {
    return Math.floor(min + Math.random() * (max + 1 - min));
  }
}

let model = new Model(new View());
