import { Status } from "./noteStatus";
import { Category } from "./noteCategory"

export interface NoteAddDTO {
  name: string;
  dueDate: Date;
  description: string;
  status: Status;
  category: Category
}