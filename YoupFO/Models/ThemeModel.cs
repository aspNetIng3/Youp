using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoupFo.Models
{
    public class ThemeModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<ThemeModel> SousForums;

        public ThemeModel(int id, int parentId, string title, string content) {
            this.Id = id;
            this.ParentId = parentId;
            this.Title = title;
            this.Content = content;
        }

        public static List<ThemeModel> getForumsAndSubforums()
        {
            return new List<ThemeModel>();
         /*
            {
                new ThemeModel(){
                    Id = 1,
                    Title = "Vie/Quotidien",
                    Content = "Description",
                    SousForums = new List<ThemeModel>(){
                        new ThemeModel(){
                            Title = "Etudiant",
                        },
                        new ThemeModel(){
                            Title = "Jeunes Parents", 
                        }
                    }
                },
                new ThemeModel(){
                    Id = 2,
                    Title = "Jeux",
                    Content = "Description",
                    SousForums = new List<ThemeModel>(){
                        new ThemeModel(){
                            Title = "Jeux Vidéos"    
                        },
                        new ThemeModel(){
                            Title = "Jeux de société"    
                        },
                        new ThemeModel(){
                            Title = "Jeux de rôle"    
                        }
                    }
                },
                new ThemeModel(){
                    Id = 3,
                    Title = "Activités",
                    Content = "Description",
                    SousForums = new List<ThemeModel>(){
                        new ThemeModel(){
                            Title = "Parc d'attraction"    
                        },
                        new ThemeModel(){
                            Title = "Zoo"    
                        },
                        new ThemeModel(){
                            Title = "Bowling"    
                        },
                        new ThemeModel(){
                            Title = "Billard"    
                        },
                        new ThemeModel(){
                            Title = "Tunning"    
                        },
                        new ThemeModel(){
                            Title = "Peinture/dessin"    
                        },
                        new ThemeModel(){
                            Title = "Lecture"    
                        }
                    }
                },
                new ThemeModel(){
                    Id = 4,
                    Title = "Sports",
                    Content = "Description",
                    SousForums = new List<ThemeModel>(){
                        new ThemeModel(){
                            Title = "Handball"    
                        },
                        new ThemeModel(){
                            Title = "Football"    
                        },
                        new ThemeModel(){
                            Title = "Foot en salle"    
                        },
                        new ThemeModel(){
                            Title = "Course à pied"    
                        },
                        new ThemeModel(){
                            Title = "Paintball"    
                        }
                    }
                },
                new ThemeModel(){
                    Id = 5,
                    Title = "Soirée",
                    Content = "Description",
                    SousForums = new List<ThemeModel>(){
                        new ThemeModel(){
                            Title = "Boîte de nuit"    
                        },
                        new ThemeModel(){
                            Title = "Restaurants"    
                        },
                        new ThemeModel(){
                            Title = "Cocktail"    
                        },
                        new ThemeModel(){
                            Title = "Exposition"    
                        },
                        new ThemeModel(){
                            Title = "Vernissage"    
                        }
                    }
                }
            };
          * */
        }
    }
}