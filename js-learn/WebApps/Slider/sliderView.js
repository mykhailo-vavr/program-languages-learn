export class SliderView {
  constructor(options) {
    this.options = options;
  }

  create() {
    let slider = document.createElement('div');
    slider.classList.add('slider');
    slider.style.height = this.options.height;
    slider.style.width = this.options.width;

    this.header = this.createComponent(
      'header',
      this.createHeaderItem
    );
    slider.append(this.header);

    this.gallery = this.createComponent(
      'gallery',
      this.createGalleryItem
    );
    slider.append(this.gallery);

    slider.insertAdjacentHTML('beforeend', this.createControls());

    this.slider = slider;
    this.options.elem.append(this.slider);
  }

  createComponent(name, createComponentItem) {
    let component = document.createElement('div');
    let positionOfItems;

    if (name == 'header') {
      component.classList.add('slider-header');
      positionOfItems = 'beforeend';
    }

    if (name == 'gallery') {
      component.classList.add('slider-gallery');
      positionOfItems = 'afterbegin';
    }

    this.options.items.forEach((item) => {
      component.insertAdjacentHTML(
        positionOfItems,
        createComponentItem(item)
      );
    });

    return component;
  }

  createHeaderItem({ h2, h4, bgColor }) {
    const standartBgColor = '#ccc';
    return `
      <div
        class="slider-header-item"
        style="background: ${bgColor || standartBgColor}"
      >
        <h2>${h2 || ''}</h2>
        <h4>${h4 || ''}</h4>
      </div>`;
  }

  createGalleryItem({ url }) {
    const standartUrl =
      'https://images.unsplash.com/photo-1525785967371-87ba44b3e6cf?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=80';

    return `
      <div
        class="slider-gallery-item"
        style="background: url(${url || standartUrl})
          no-repeat center center / cover">
      </div>`;
  }

  createControls() {
    return `
      <div class="slider-controls">
        <button class="up-btn btn" data-action="moveUp">
          &#129045;
        </button>
        <button class="down-btn btn" data-action="moveDown">
         &#129047;
       </button>
      </div>`;
  }
}
