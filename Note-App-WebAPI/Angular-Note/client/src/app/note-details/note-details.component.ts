import { Component, OnInit } from '@angular/core';
import { Note } from '../models/note';
import { NotesService } from '../notes/notes.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrls: ['./note-details.component.scss']
})
export class NoteDetailComponent implements OnInit{
  noteId: number | null = null;
  note: Note | undefined;
  showErrorToast = false;

  constructor(private route: ActivatedRoute,private notesService: NotesService) { }


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const noteId = +params['id'];
      if (!isNaN(noteId)) {
        this.fetchNoteDetails(noteId);
      } else {
        this.showErrorToast = true;
      }
    });
  }

  fetchNoteDetails(noteId: number): void {
    this.notesService.getNoteById(noteId).subscribe({
      next: note => this.note = note,
      error: () => this.showErrorToast = true
    });
  }

  getNote(): void {
    if (this.noteId && this.noteId > 0) {
      this.notesService.getNoteById(this.noteId).subscribe({
        next: (data) => {
          this.note = data;
          this.showErrorToast = false;
        },
        error: (err) => {
          console.error(err);
          this.note = undefined; 
          this.showErrorToast = true; 
          setTimeout(() => this.showErrorToast = false, 4000); 
        }
      });
    } else {
      this.note = undefined; 
      this.showErrorToast = true; 
      setTimeout(() => this.showErrorToast = false, 4000); 
    }
  }
}