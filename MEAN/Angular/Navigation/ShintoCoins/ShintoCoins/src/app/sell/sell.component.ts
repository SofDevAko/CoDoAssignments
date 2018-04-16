import { Component, OnInit } from '@angular/core';
import { ShintoService } from '../shinto.service'
@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {
  svalue;
  samount;
  int;
  message;
  constructor(private _shintoService:ShintoService) { }

  ngOnInit() {
    this.getInfo()
  }
  getInfo(){
    var res = this._shintoService.getInfo();
    this.svalue = res.data.svalue;
    this.samount = res.data.samount;
  }
  sellCoin(){
    if(this.int>this.samount){
      this.message = "You don't have that many to sell!"
    }
    else{
      this._shintoService.sellCoin({'action': 'sold', 'amount':this.int, 'value':this.svalue});
      this.getInfo();
      this.message=null;
    }
  }


}
