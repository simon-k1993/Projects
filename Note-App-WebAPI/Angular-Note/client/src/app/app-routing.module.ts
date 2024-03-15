import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotesComponent } from './notes/notes.component';
import { NoteDetailComponent } from './note-details/note-details.component';
import { NoteCreateComponent } from './create/create.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { authGuard } from './auth.guard';
import { CategorySearchComponent } from './category-search/category-search.component';
import { SearchTermComponent } from './search-term/search-term.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  {
    path: 'protected',
    loadChildren: () => import('./protected/protected.module').then(m => m.ProtectedModule),
    canActivate: [authGuard]
  },
  { path: 'notes', component: NotesComponent, canActivate: [authGuard] },
  { path: 'notes', component: NotesComponent },
  { path: 'note-details/:id', component: NoteDetailComponent },
  { path: 'create-note', component: NoteCreateComponent },
  { path: 'category-note', component: CategorySearchComponent },
  { path: 'search-note', component: SearchTermComponent },
  { path: 'update/:id', component: UpdateNoteComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
