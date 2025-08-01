﻿namespace ToDoApp.Models
{
    public class ToDoItemsRepository
    {
        private static List<ToDoItem> items = new List<ToDoItem>()
        {
            new ToDoItem {  Id = 1, Name = "Task 1"},
            new ToDoItem {  Id = 2, Name = "Task 2"},
            new ToDoItem {  Id = 3, Name = "Task 3"},
            new ToDoItem {  Id = 4, Name = "Task 4"},
        };

        public static void AddItem(ToDoItem item)
        {
            if(items.Count > 0)
            {
                var maxId = items.Max(i => i.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }
            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        
        public static List<ToDoItem> GetItems()
        {
            var sortedItems = items.OrderBy(item => item.IsCompleted).ThenByDescending(item => item.Id).ToList();
            return sortedItems;
        }

        public static ToDoItem? GetServerById(int id)
        {
            var item = items.FirstOrDefault(s => s.Id == id);
            if (item != null)
            {
                return new ToDoItem
                {
                    Id = item.Id,
                    Name = item.Name
                };
            }

            return null;
        }

        public static void UpdateItem(int itemId, ToDoItem item)
        {
            if (itemId != item.Id) return;

            var itemToUpdate = items.FirstOrDefault(s => s.Id == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
            }
        }

        public static void DeleteItem(int itemId)
        {
            var item = items.FirstOrDefault(s => s.Id == itemId);
            if (item != null)
            {
                items.Remove(item);
            }
        }

        public static List<ToDoItem> SearchItems(string itemFilter)
        {
            return items.Where(s => s.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
