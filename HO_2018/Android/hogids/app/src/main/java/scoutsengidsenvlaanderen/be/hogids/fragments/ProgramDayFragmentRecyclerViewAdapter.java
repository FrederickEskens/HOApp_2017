package scoutsengidsenvlaanderen.be.hogids.fragments;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import scoutsengidsenvlaanderen.be.hogids.R;
import scoutsengidsenvlaanderen.be.hogids.fragments.dummy.DummyContent.DummyItem;

import java.util.List;


public class ProgramDayFragmentRecyclerViewAdapter extends RecyclerView.Adapter<ProgramDayFragmentRecyclerViewAdapter.ViewHolder> {

    private final List<DummyItem> mValues;

    public ProgramDayFragmentRecyclerViewAdapter(List<DummyItem> items) {
        mValues = items;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.fragment_programdayfragment, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        holder.mItem = mValues.get(position);
        holder.mIdView.setText(mValues.get(position).id);
        holder.mContentView.setText(mValues.get(position).content);
        holder.mLocationView.setText(mValues.get(position).details);

        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        public final View mView;
        public final TextView mIdView;
        public final TextView mContentView;
        public final TextView mLocationView;
        public DummyItem mItem;

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mIdView = (TextView) view.findViewById(R.id.lblHour);
            mContentView = (TextView) view.findViewById(R.id.lblTitle);
            mLocationView = (TextView) view.findViewById(R.id.lblLocation);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mContentView.getText() + "'";
        }
    }
}
