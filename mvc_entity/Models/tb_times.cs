//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvc_entity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_times
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_times()
        {
            this.tb_jogador = new HashSet<tb_jogador>();
        }
    
        public int id_time { get; set; }
        public string nome_time { get; set; }
        public Nullable<int> qtd_jogadores { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_jogador> tb_jogador { get; set; }
    }
}