import { Component, EventEmitter, Output } from '@angular/core';
import { Note } from '../models/note';
import { NotesService } from '../notes/notes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-search',
  templateUrl: './category-search.component.html',
  styleUrls: ['./category-search.component.scss']
})
export class CategorySearchComponent {
  @Output() updateNote: EventEmitter<number> = new EventEmitter<number>();
  @Output() viewNote: EventEmitter<number> = new EventEmitter<number>();
  @Output() deleteNote: EventEmitter<number> = new EventEmitter<number>();
  @Output() notesFiltered: EventEmitter<Note[]> = new EventEmitter<Note[]>();
  filteredNotes: Note[] = [];

  constructor(private noteService: NotesService,private router: Router) {}

  filterNotesByCategory(category: string): void {
    if (typeof category === 'string') {
      this.noteService.filterNotesByCategory(category).subscribe({
        next: (notes) => {
          this.filteredNotes = notes;
          this.notesFiltered.emit(notes);
        },
        error: (error) => console.error('Error filtering notes:', error)
      });
    }
  }

  goToUpdateNote(noteId: number): void {
    this.router.navigate(['/update', noteId]);
  }

  goToNoteDetails(noteId: number): void {
    this.router.navigate(['/note-details', noteId]);
  }

  deleteNoteById(noteId: number): void {
    const confirmed = window.confirm('Are you sure you want to delete this note?');
    if (confirmed) {
        this.noteService.deleteNote(noteId).subscribe({
            next: () => {

                this.filteredNotes = this.filteredNotes.filter(note => note.id !== noteId);
            },
            error: error => console.error('Error deleting note:', error)
        });
    }
}
}