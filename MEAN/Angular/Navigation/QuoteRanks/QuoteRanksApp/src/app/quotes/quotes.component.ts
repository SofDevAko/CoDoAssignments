import { Component, OnInit } from '@angular/core';
import { QuoterService } from '../quoter.service'
import { ActivatedRoute, Params, Router} from '@angular/router';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css']
})
export class QuotesComponent implements OnInit {
quotes;
author;
id;
  constructor(
    private _quoterService : QuoterService,

    private _router : Router,

    private _route : ActivatedRoute
  ) { }

  ngOnInit() {
    this._route.params.subscribe((params: Params) => this.id = params['id']);

    let observable = this._quoterService.showAuthor(this.id)
    observable.subscribe(data => {
      console.log(data)
    this.quotes = data['author']['quotes']
    this.author = data['author']['name']
    console.log(this.quotes)
    })
  }
}
