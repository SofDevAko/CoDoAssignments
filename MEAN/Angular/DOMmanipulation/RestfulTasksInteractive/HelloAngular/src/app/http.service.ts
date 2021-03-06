import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Injectable()
export class HttpService {

  getTasks(){
    // our http response is an Observable, store it in a variable
    let tempObservable = this._http.get('/tasks');
    // subscribe to the Observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Got our tasks!", data));
    return this._http.get('/tasks');
 }
  constructor(private _http: HttpClient) { 

    this.getTasks();
   }
  //  getTaskId(id){
  //   let tempObservable = this._http.get('/tasks/:id');
  //   tempObservable.subscribe(data => console.log("Got task by ID!", data));
  //   return this._http.get('/tasks/:id');
  //  }

}
