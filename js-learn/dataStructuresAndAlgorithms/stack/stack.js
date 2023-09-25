// Support class Node
class Node {
  constructor(data, pNext = null) {
    this.data = data;
    this.pNext = pNext;
  }
}

// Main class Stack
class Stack {
  constructor() {
    this.head = null;
    this.size = 0;
  }

  push(data) {
    if (!this.head) {
      this.head = new Node(data);
      this.size++;
      return;
    }

    this.head = new Node(data, this.head);
    this.size++;
  }

  pop() {
    if (!this.head) {
      return;
    }

    this.head = this.head.pNext;
    this.size--;
  }

  isEmpty() {
    return this.size === 0;
  }

  getHead() {
    return this.head == null ? null : this.head.data;
  }

  clear() {
    // while (this.size) {
    // this.pop();
    // }
    this.head = null;
    this.size = 0;
  }
}

let stack = new Stack();
stack.push(1);
stack.push(2);
stack.push(3);
stack.push(4);
stack.pop();
console.log(stack.getHead());
console.log(stack.isEmpty());
stack.clear();
console.log(stack.getHead());
console.log(stack.isEmpty());

console.log(stack);
