﻿using UserCommunicationService.Core.Services.Chats.ChatsModels;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class FetchChatsInput
    {
        public FetchChatsInput(Guid userId,  byte[] pagingState, int pageSize = 5)
        {
            UserId = userId;
            PageSize = pageSize;
            PagingState = pagingState;
        }


        public Guid UserId { get; set; }
        public int PageSize { get; set; }
        public byte[] PagingState { get; set; }



        public FetchChatsInputCore ToCore()
        {
            var result = new FetchChatsInputCore(userId: UserId, pageSize: PageSize, pagingState: PagingState);
            return result;
        }
    }
}
