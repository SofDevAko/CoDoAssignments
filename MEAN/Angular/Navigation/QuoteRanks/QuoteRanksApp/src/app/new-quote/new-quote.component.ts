import { Component, OnInit } from '@angular/core';
import { QuoterService } from '../quoter.service'
import { ActivatedRoute, Params, Router} from '@angular/router';

@Component({
  selector: 'app-new-quote',
  templateUrl: './new-quote.component.html',
  styleUrls: ['./new-quote.component.css']
})
export class NewQuoteComponent implements OnInit {
  quotes;
  author;
  id;
  newquote ="";
  message;
  constructor(
    private _quoterService : QuoterService,

    private _router : Router,

    private _route : ActivatedRoute
  ) { }

  ngOnInit() {
    this._route.params.subscribe((params: Params) => this.id = params['id']);

    let observable = this._quoterService.showAuthor(this.id)
    observable.subscribe(data => {

    this.quotes = data['author']['quotes']

    this.author = data['author']['name']
    })
  }
  createQuote(){
    let observable = this._quoterService.addQuote({_author: this.id, content: this.newquote})
    observable.subscribe(data => {
      if(data['error']){this.message = data['error']['message']}
      else{
        this.quotes = data['author']['quotes']
        this.author = data['author']['name']
        this.message = "Quote added!"
      }
      })
      this.newquote = "";
  }

}
