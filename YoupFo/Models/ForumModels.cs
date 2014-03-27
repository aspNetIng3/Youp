using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoupFo.Models
{
    public class ForumModels
    {
        public int Id { get; set; }
        public int Parent_id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<ForumModels> SousForums;

        public static List<ForumModels> getForumsAndSubforums()
        {
            return new List<ForumModels>()
            {
                new ForumModels(){
                    Id = 1,
                    Title = "Vie/Quotidien",
                    Content = "Description",
                    SousForums = new List<ForumModels>(){
                        new ForumModels(){
                            Title = "Etudiant",
                        },
                        new ForumModels(){
                            Title = "Jeunes Parents", 
                        }
                    }
                },
                new ForumModels(){
                    Id = 2,
                    Title = "Jeux",
                    Content = "Description",
                    SousForums = new List<ForumModels>(){
                        new ForumModels(){
                            Title = "Jeux Vidéos"    
                        },
                        new ForumModels(){
                            Title = "Jeux de société"    
                        },
                        new ForumModels(){
                            Title = "Jeux de rôle"    
                        }
                    }
                },
                new ForumModels(){
                    Id = 3,
                    Title = "Activités",
                    Content = "Description",
                    SousForums = new List<ForumModels>(){
                        new ForumModels(){
                            Title = "Parc d'attraction"    
                        },
                        new ForumModels(){
                            Title = "Zoo"    
                        },
                        new ForumModels(){
                            Title = "Bowling"    
                        },
                        new ForumModels(){
                            Title = "Billard"    
                        },
                        new ForumModels(){
                            Title = "Tunning"    
                        },
                        new ForumModels(){
                            Title = "Peinture/dessin"    
                        },
                        new ForumModels(){
                            Title = "Lecture"    
                        }
                    }
                },
                new ForumModels(){
                    Id = 4,
                    Title = "Sports",
                    Content = "Description",
                    SousForums = new List<ForumModels>(){
                        new ForumModels(){
                            Title = "Handball"    
                        },
                        new ForumModels(){
                            Title = "Football"    
                        },
                        new ForumModels(){
                            Title = "Foot en salle"    
                        },
                        new ForumModels(){
                            Title = "Course à pied"    
                        },
                        new ForumModels(){
                            Title = "Paintball"    
                        }
                    }
                },
                new ForumModels(){
                    Id = 5,
                    Title = "Soirée",
                    Content = "Description",
                    SousForums = new List<ForumModels>(){
                        new ForumModels(){
                            Title = "Boîte de nuit"    
                        },
                        new ForumModels(){
                            Title = "Restaurants"    
                        },
                        new ForumModels(){
                            Title = "Cocktail"    
                        },
                        new ForumModels(){
                            Title = "Exposition"    
                        },
                        new ForumModels(){
                            Title = "Vernissage"    
                        }
                    }
                }
            };
        }
    }
}