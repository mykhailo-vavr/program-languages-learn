class Slider {
  constructor(options) {
    this.options = options;
    this.boundOnClick = this.onClick.bind(this);
  }

  create() {
    let sliderItems = this.createSliderItems();
    this.sliderItems = sliderItems;

    this.currentItem =
      sliderItems[Math.floor(sliderItems.length / 2)];
    this.currentItem.classList.add('active');

    let slider = document.createElement('div');
    slider.classList.add('slider');
    this.options.elem.append(slider);
    this.slider = slider;

    slider.append(...sliderItems);
  }

  createSliderItems() {
    return this.options.images.map(({ url, title }) => {
      return this.createSliderItem(url, title);
    });
  }

  createSliderItem(url, title) {
    let sliderItem = document.createElement('div');
    sliderItem.classList.add('slider-item');
    sliderItem.style.backgroundImage = `url(${url || ''})`;

    let h3 = document.createElement('h3');
    h3.textContent = title || '';
    sliderItem.append(h3);

    sliderItem.addEventListener('click', this.boundOnClick);

    console.log(sliderItem);

    return sliderItem;
  }

  onClick(event) {
    this.currentItem.classList.remove('active');
    this.currentItem = event.target;
    this.currentItem.classList.add('active');
  }

  destroy() {
    this.sliderItems.forEach((item) => {
      item.removeEventListener('click', this.boundOnClick);
    });
    this.options.elem.remove(this.slider);
  }
}

let slider = new Slider({
  elem: document.querySelector('.container'),
  images: [
    {
      url: 'https://images.unsplash.com/photo-1589656966895-2f33e7653819?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80',
      title: 'Bear',
    },
    {
      url: 'https://images.unsplash.com/photo-1425082661705-1834bfd09dca?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=755&q=80',
      title: 'Hamster',
    },
    {
      url: 'https://images.unsplash.com/photo-1489084917528-a57e68a79a1e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80',
      title: 'Cat',
    },
    {
      url: 'https://images.unsplash.com/photo-1470093851219-69951fcbb533?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80',
      title: 'Polar fox',
    },
    {
      url: 'https://images.unsplash.com/photo-1506099914961-765be7a97019?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80',
      title: 'Deer',
    },
  ],
});

slider.create();
// slider.destroy();
