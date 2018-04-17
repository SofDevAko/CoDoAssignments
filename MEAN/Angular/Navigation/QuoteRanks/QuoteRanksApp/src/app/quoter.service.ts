import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuoterService {

  constructor(private _http: HttpClient) {
    this.getAuthors();
  }

  getAuthors(){
    return this._http.get('/authors');
  }
  addAuthor(newauthor){  //CREATE
    return this._http.post('/authors', newauthor)
  }
  showAuthor(id){  //READ
    return this._http.get("/authors/"+id+"/quotes")
  }
  updateAuthor(editauthor, id){  //UPDATE
    return this._http.put("/authors/"+id+"", editauthor)
  }
  deleteAuthor(id) {  //DESTROY
    return this._http.delete("/authors/"+id)
  }
  addQuote(id,data){
    return this._http.post("/authors/"+id+"/quotes",data)
  }
}