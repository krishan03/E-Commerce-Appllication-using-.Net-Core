export class OperationResult<T> {
    data: T
    isSuccess: boolean
    associatedMessages: string[]
}