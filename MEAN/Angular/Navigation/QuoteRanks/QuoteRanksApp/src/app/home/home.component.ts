import { Component, OnInit } from '@angular/core';
import { QuoterService } from '../quoter.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  authors;
  author;
  constructor(private _quoterService:QuoterService) { }

  ngOnInit() {
    this.getAuthors()
  }
  getAuthors(){
    let observable = this._quoterService.getAuthors();
    observable.subscribe(data => {
      console.log(data),
      this.authors = data['data']})
  }
  deleteAuthor(id){
    let observable = this._quoterService.deleteAuthor(id);
    observable.subscribe(data => {
      console.log(data),
      this.authors = data['data']})
  }

}
