import { TagGroup } from "./tag-group";

export class Product {
    Id: string
    InStock: boolean
    Name: string
    ShortDescription: string
    LongDescription: string
    Categories: string[]
    DynamicCategories: string[]
    Price: number
    TagGroups: TagGroup[]
    Thumbnail: string
    ImageUrl: string[]
    Rating: number
}