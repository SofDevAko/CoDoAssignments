import { Component, OnInit } from '@angular/core';
import { ShintoService } from '../shinto.service'
@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {
  svalue;
  samount;
  int;

  constructor(private _shintoService:ShintoService) { }

  ngOnInit() {
  this.getInfo();
  }
  getInfo(){
    var res = this._shintoService.getInfo();
    this.svalue = res.data.svalue;
    this.samount = res.data.samount;
  }
  buyCoin(int){
    this.samount = this._shintoService.buyCoin({'action':'bought', 'amount' : this.int, 'value': this.svalue})
    this.getInfo();
    this.int = null;
  }
}
