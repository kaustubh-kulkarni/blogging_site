import { User } from "./user"

export interface Blog{
    blogid: number
    title: string
    content: string
    user: User
}