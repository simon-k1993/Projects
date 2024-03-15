import { Note } from "./note";

interface NotesPaginationResponse {
  notes: Note[];
  total: number;
}