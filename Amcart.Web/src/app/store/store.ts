// import { TEST_FIRST, TEST_SECOND } from "./actions";

// export interface IAppState {
//     data: string,
//     lastUpdate: Date;
// }

// export const INITIAL_STATE: IAppState = {
//     data: 'Initial State',
//     lastUpdate: null
// }

// export function rootReducer(state, action): IAppState {
//     switch (action.type) {
//         case TEST_FIRST:
//             return Object.assign({}, state, {
//                 data: 'Test First',
//                 lastUpdate: new Date()
//             });
//         case TEST_SECOND:
//             return Object.assign({}, state, {
//                 data: 'Test Second',
//                 lastUpdate: new Date()
//             });
//     }
//     return state;
// }