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
likeCount;
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
  like(qid){
    let observable = this._quoterService.showQuote(qid)
    observable.subscribe(data => {
      this.likeCount = data['quote']['likeCount'];
      this.likeCount +=1;
      let observable2 = this._quoterService.updateQuote(qid,{likeCount:this.likeCount})
      observable2.subscribe(data2 => {
      this.author = data2['author']['name'];
      this.quotes = data2['author']['quotes']})
    })
    
  }
  dislike(qid){
    let observable = this._quoterService.showQuote(qid)
    observable.subscribe(data => {
      this.likeCount = data['quote']['likeCount']
      this.likeCount -= 1;
      let observable2 = this._quoterService.updateQuote(qid,{likeCount:this.likeCount})
      observable2.subscribe(data2 => {
      this.author = data2['author']['name'];
      this.quotes = data2['author']['quotes']})
    })
    let observable2 = this._quoterService.updateQuote(qid,{likeCount:this.likeCount})
    observable2.subscribe(data2 => {this.author = data2['author']['name'], this.quotes = data2['author']['quotes']})
  }
  deleteQuote(qid){
    let observable = this._quoterService.deleteQuote(qid)
    observable.subscribe(data => {this.author = data['author']['name'], this.quotes = data['author']['quotes']})
  }
}
