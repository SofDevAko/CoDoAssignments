import { Component, OnInit } from '@angular/core';
import { QuoterService } from '../quoter.service'
import { ActivatedRoute, Params, Router} from '@angular/router';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  author;
  editauthor;
  message;
  id;
  constructor(private _quoterService : QuoterService,

    private _router : Router,

    private _route : ActivatedRoute) { }

  ngOnInit() {
    this._route.params.subscribe((params: Params) => this.id = params['id']);

    let observable = this._quoterService.showAuthor(this.id)
    observable.subscribe(data => {
    this.author = data['author']['name']
    })
  }
  editAuthor(){
    let jsonauthor = {name: this.editauthor}
    let observable = this._quoterService.updateAuthor(jsonauthor,this.id)
    observable.subscribe(data => {this.author = data['author']['name']})
    this.editauthor = "";
    this.message = "Author Updated!"
  }
}
