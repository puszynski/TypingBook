import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'typing',
  templateUrl: './typing.component.html',
})

export class TypingComponent {
  public title = "This is my new component"

  public mybook = {
    Title: 'Test',
    Author: 'Jakub Puszyński',
    Content: 'Raz dwa trzy Raz dwa trzy Raz dwa trzy Raz dwa trzy Raz dwa trzy Raz dwa trzy '
  };

  public book: IBook[];
  constructor(http: HttpClient) {
    //TODO - get book from API
    http.get<IBook[]>('http://localhost:5000/api/book/1').subscribe(result => {
      this.book = result;
    }, error => console.error(error));
  }   
}

interface IBook {
  id: number;
  title: string;
  author: string;
  content: string;
}
