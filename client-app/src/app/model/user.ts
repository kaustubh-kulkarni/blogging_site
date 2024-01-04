import { Blog } from "./blog"

export interface User{
    id: number
    firstname: string
    lastname: string
    email: string
    password: string
    blogs: Blog[]
}