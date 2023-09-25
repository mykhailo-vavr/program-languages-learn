export class SliderModel {
  constructor(header, gallery) {
    this.header = header;
    this.gallery = gallery;
    this.position = 0;
    this.height = this.header.clientHeight;
    this.imageCount = this.header.querySelectorAll(
      '.slider-header-item'
    ).length;
    this.setStartingSettings();
  }

  setStartingSettings() {
    this.setListeners();
    this.setStartingPosition();
  }

  setListeners() {
    this.boundOnClick = this.onClick.bind(this);
    document.addEventListener('click', this.boundOnClick);
  }

  setStartingPosition() {
    this.header.style.transform = `translateY(-${
      (this.imageCount - 1) * this.height
    }px)`;
  }

  onClick(event) {
    const action = event.target.dataset.action;
    if (action) {
      this[action]();
    }
  }

  moveUp() {
    this.changeSlide('up');
  }

  moveDown() {
    this.changeSlide('down');
  }

  changeSlide(direction) {
    let position = this.position;
    let height = this.height;

    if (direction == 'up') {
      position += height;

      if (position > height * (this.imageCount - 1)) {
        position = 0;
      }
    } else {
      position -= height;

      if (position < 0) {
        position = (this.imageCount - 1) * height;
      }
    }

    this.header.style.transform = `translateY(-${
      (this.imageCount - 1) * height - position
    }px)`;
    this.gallery.style.transform = `translateY(-${position}px)`;
    this.position = position;
  }
}
