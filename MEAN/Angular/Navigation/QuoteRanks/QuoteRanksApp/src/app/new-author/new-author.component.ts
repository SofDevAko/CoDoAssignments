import { QuoterService } from '../quoter.service'
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-author',
  templateUrl: './new-author.component.html',
  styleUrls: ['./new-author.component.css']
})
export class NewAuthorComponent implements OnInit {
  author;
  newauthor;
  message;
  constructor(private _quoterService:QuoterService) { }

  ngOnInit() {
  }
  createAuthor(){
    let jsonauthor = {name: this.newauthor, quotes: []}
    let observable = this._quoterService.addAuthor(jsonauthor)
    observable.subscribe(data => {
      if(data['error']){this.message = data['error']['message']}
      else{this.message = "Author Created!"}
      })
    this.newauthor = "";
  }
}
