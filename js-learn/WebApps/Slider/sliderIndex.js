import { SliderController as Slider } from './sliderController.js';

let slider = new Slider({
  elem: document.querySelector('.container'),
  height: '100vh',
  width: '100vw',
  items: [
    {
      h2: 'Session is coming',
      h4: 'But I am not afraid',
      bgColor: `linear-gradient(36deg, rgba(144,140,133,1) 0%, rgba(153,138,118,1) 33%, rgba(161,141,115,1) 65%, rgba(170,137,90,1) 94%)`,
      url: 'https://images.unsplash.com/photo-1607604276583-eef5d076aa5f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=80',
    },
    {
      h2: 'Final Boss',
      h4: 'But I am ready',
      bgColor: `linear-gradient(36deg, rgba(51,191,185,1) 0%, rgba(36,187,132,1) 3%, rgba(152,193,170,1) 100%, rgba(0,167,173,1) 100%)`,
      url: 'https://images.unsplash.com/photo-1571757767119-68b8dbed8c97?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=80',
    },
    {
      h2: 'Сelebrate Passing Exams',
      h4: 'I am so happy',
      bgColor: `linear-gradient(36deg, rgba(51,191,185,1) 0%, rgba(177,122,109,1) 0%, rgba(193,101,79,1) 65%, rgba(216,74,40,1) 94%`,
      url: 'https://images.unsplash.com/photo-1594877502388-8d9e1dfcd84b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=800&q=80',
    },
    {
      h2: 'Сhimchikuyu In The University',
      h4: 'It would be better to sleep',
      bgColor: `linear-gradient(
        36deg,
        rgba(36, 187, 132, 1) 0%,
        rgba(152, 139, 29, 1) 0%,
        rgba(145, 141, 12, 1) 50%,
        rgba(152, 173, 0, 1) 100%
      )`,
      url: 'https://images.unsplash.com/photo-1610568781018-995405522539?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=80',
    },
  ],
});

slider.create();
