import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Note } from '../models/note';
import { NoteAddDTO } from '../models/noteAdd';
import { Observable } from 'rxjs';
import { NoteUpdate } from '../models/noteUpdate';


@Injectable({
  providedIn: 'root'
})
export class NotesService {
  baseUrl = 'http://localhost:5135/api/'

  constructor(private http: HttpClient) { }


  getNotes(page: number, pageSize: number): Observable<Note[]> {
    let params = new HttpParams()
        .set('page', page.toString())
        .set('pageSize', pageSize.toString());
  
    return this.http.get<Note[]>(`http://localhost:5135/api/notes/paged`, { params });
  }


  getNoteById(id: number): Observable<Note> {
    return this.http.get<Note>(`http://localhost:5135/api/notes/${id}`);
  }
  

  addNote(note: NoteAddDTO): Observable<any> {
    return this.http.post(this.baseUrl + 'notes', note, { responseType: 'text' });
  }

  updateNote(id: number, note: NoteUpdate): Observable<string> {
    return this.http.put(`http://localhost:5135/api/notes/${id}`, note, { responseType: 'text' });
  }


  deleteNote(noteId: number): Observable<string> {
    return this.http.delete(`http://localhost:5135/api/notes/${noteId}`, { responseType: 'text' });
}

  searchNotes(searchTerm: string): Observable<Note[]> {
    let params = new HttpParams().set('searchTerm', searchTerm);
    return this.http.get<Note[]>(`http://localhost:5135/api/notes/search`, { params });
}

filterNotesByCategory(category: string): Observable<Note[]> {
  return this.http.get<Note[]>(`http://localhost:5135/api/notes/filter`, { params: { category } });
}

}
